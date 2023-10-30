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

        Task<ObjectId> UniversityRegister(string university);

        Task<ObjectId> CollegeRegister(string college, ObjectId universityId);

        Task<ObjectId> UserRegister(string username, string password, string studId, string email, ObjectId collegeId);
        Task<UserModel> GetUserByUserName(string userName);
        Task UpdateUserPassword(RequestPasswordDto requestPasswordDto);
        Task<OtpVerification> VerifyOtp(string userName, string otpCode);
        Task UpdateNewPassword(string userName, string newPassword);

    }
}
