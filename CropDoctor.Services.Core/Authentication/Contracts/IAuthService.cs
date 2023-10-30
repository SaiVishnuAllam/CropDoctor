using CropDoctor.Services.Core.Authentication.Dtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Authentication.Contracts
{
    public interface IAuthService
    {
        Task<LoginDto> Authentication(UserDto userDto);
        Task<ObjectId> UserRegistration(RegistrationDto registrationDto);
    }
}
