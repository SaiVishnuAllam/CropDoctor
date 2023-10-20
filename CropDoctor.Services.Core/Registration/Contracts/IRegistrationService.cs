using CropDoctor.Services.Core.Registration.Dtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Registration.Contracts
{
    public interface IRegistrationService
    {
        Task<ObjectId> UserRegistration(RegistrationDto registrationDto);
    }
}
