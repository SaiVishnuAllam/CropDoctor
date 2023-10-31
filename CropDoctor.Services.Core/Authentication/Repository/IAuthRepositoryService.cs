using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Data.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CropDoctor.Services.Core.Authentication.Dtos.RequestPaswordDto;

namespace CropDoctor.Services.Core.Authentication.Repository
{
    public interface IAuthRepositoryService
    {
        Task<UserDetailsModel> AuthVerify(UserDto userDto);

        Task<string> UniversityRegister(string university);

        Task<string> CollegeRegister(string college, string universityId);

        Task<string> UserRegister(string username, string password, string studId, string email, string collegeId);
        Task<UserModel> GetUserByUserName(string userName);
        Task UpdateUserPassword(RequestPasswordDto requestPasswordDto);
        Task<OtpVerification> VerifyOtp(string userName, string otpCode);
        Task UpdateNewPassword(string userName, string newPassword);

    }
}
