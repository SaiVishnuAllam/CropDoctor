using CropDoctor.Services.Core.Authentication.Contracts;
using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Authentication.Repository;
using CropDoctor.Services.Core.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static CropDoctor.Services.Core.Authentication.Dtos.RequestPaswordDto;

namespace CropDoctor.Services.Core.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepositoryService _authRepositoryService;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepositoryService authRepositoryService, IConfiguration configuration)
        {
            _authRepositoryService = authRepositoryService;
            _configuration = configuration;
        }

        
        public async Task<LoginDto> Authentication(UserDto userDto)
        {
            var result = await _authRepositoryService.AuthVerify(userDto);

            if (result == null)
            {
                throw new UnauthorizedException("UserName and password is invalid !!!");
                //return "login";
            }
            else if (result.IsActive == false)
            {
                //return "invalid";
                throw new UnauthorizedException("User is not allowed temporarily!!");
            }

            if (userDto.UniversityName.Equals(result.UniversityName))
            {
                if (userDto.CollegeName.Equals(result.CollegeName))
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature
                        );

                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,userDto.UserName)
                    });
                    int time = 2;
                    var expires = DateTime.UtcNow.AddHours(time);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    LoginDto response = new LoginDto
                    {
                        AccessToken = jwtToken,
                        TokenExpiryHours = time,
                        Username = result.UserName,
                        Password = result.Password,
                        CollegeName = result.CollegeName,
                        UniversityName = result.UniversityName,
                        UserId = result.Id
                    };
                    return response;
                }
                throw new UnauthorizedException("College is not registered !!");
                //return "college";
            }
            throw new UnauthorizedException("University is not registered !!");
            //return "university";
        }

        public async Task<ObjectId> UserRegistration(RegistrationDto registrationDto)
        {
            var university = await _authRepositoryService.UniversityRegister(registrationDto.UniversityName);
            if (university == ObjectId.Empty)
                throw new InternalServerErrorException("Unable to add or get university to Database");
            var college = await _authRepositoryService.CollegeRegister(registrationDto.CollegeName, university);
            if (college == ObjectId.Empty)
                throw new InternalServerErrorException("Unable to add or get college to Database");
            var user = await _authRepositoryService.UserRegister(registrationDto.Username, registrationDto.Password, registrationDto.StudentId, registrationDto.Email, college);
            if (user == ObjectId.Empty)
                throw new InternalServerErrorException("Unable to add or get User Details to Database");
            return user;

        }

        public async Task<IDictionary<string, string>> ResetPassword(RequestPasswordDto requestPasswordDto)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            var userDetails = await _authRepositoryService.GetUserByUserName(requestPasswordDto.UserName) ?? throw new Exception("Invalid user name");

            bool isOldPasswordMatched = false;
            if (requestPasswordDto.ChangeType.Equals("RESET"))
            {
                if (!requestPasswordDto.OldPassword.Equals(userDetails.Password))
                {
                    throw new Exception("Old Password didn't matched, please try again");
                }
            }
            isOldPasswordMatched = requestPasswordDto.ChangeType.Equals("RESET") && requestPasswordDto.OldPassword.Equals(requestPasswordDto.NewPassword) ? true : false;
            if (isOldPasswordMatched)
            {
                throw new Exception("New Password should not be same as previous password");
            }
            await _authRepositoryService.UpdateUserPassword(requestPasswordDto).ConfigureAwait(false);

            result.Add("status", "Password changed successfully");
            return result;
            
        }

        /// <summary>
        /// Method to reset the password using the received OTP code and new password
        /// </summary>
        /// <param name="requestPasswordDto"></param>
        /// <returns></returns>
        /// <exception cref="BighaatBaseException"></exception>
        public async Task<IDictionary<string, string>> UpdatePassword(RequestPasswordDto requestPasswordDto)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            // condition to Check user is valid user or not
            var userDetails = await _authRepositoryService.GetUserByUserName(requestPasswordDto.UserName) ?? throw new Exception("Invalid user name, please try again");

            //condition to Check if the OTP code provided is valid or not
            var otp = await _authRepositoryService.VerifyOtp(requestPasswordDto.UserName, requestPasswordDto.OtpCode) ?? throw new Exception("Invalid or expired OTP code. Please request a new one");

            // Update the user's password with the new one
            await _authRepositoryService.UpdateNewPassword(requestPasswordDto.UserName, requestPasswordDto.NewPassword);

            result.Add("status", "Password changed successfully");
            return result;
            
        }
    }
}

