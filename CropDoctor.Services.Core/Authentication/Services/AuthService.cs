using CropDoctor.Services.Core.Authentication.Contracts;
using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Authentication.Repository;
using CropDoctor.Services.Core.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<string> Authentication(UserDto userDto)
        {
            var result = await _authRepositoryService.AuthVerify(userDto);
            
            if (result == null)
            {
                throw new UnauthorizedException("UserName and password are invalid !!!");
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

                    var expires = DateTime.UtcNow.AddMinutes(1.5);

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

                    return jwtToken;
                }
                throw new UnauthorizedException("College is not registered !!");
                //return "college";
            }
            throw new UnauthorizedException("University is not registered !!");
            //return "university";
        }
    }
}

