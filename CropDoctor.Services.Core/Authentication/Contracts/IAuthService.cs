using CropDoctor.Services.Core.Authentication.Dtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CropDoctor.Services.Core.Authentication.Dtos.RequestPaswordDto;

namespace CropDoctor.Services.Core.Authentication.Contracts
{
    public interface IAuthService
    {
        Task<LoginDto> Authentication(UserDto userDto);
        Task<string> UserRegistration(RegistrationDto registrationDto);
        //Task<IDictionary<string, string>> ResetPassword(RequestPasswordDto requestPasswordDto);
        Task<IDictionary<string, string>> UpdatePassword(RequestPasswordDto requestPasswordDto);
    }
}
