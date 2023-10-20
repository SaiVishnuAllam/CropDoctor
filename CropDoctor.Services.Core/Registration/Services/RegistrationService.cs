using CropDoctor.Services.Core.Registration.Contracts;
using CropDoctor.Services.Core.Registration.Dtos;
using CropDoctor.Services.Core.Registration.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Registration.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepositoryService _registrationRepositoryService;

        public RegistrationService(IRegistrationRepositoryService registrationRepositoryService)
        {
            _registrationRepositoryService = registrationRepositoryService;
        }

        public async Task<ObjectId> UserRegistration(RegistrationDto registrationDto)
        {
            var university = await _registrationRepositoryService.UniversityRegister(registrationDto.UniversityName);
            var college = await _registrationRepositoryService.CollegeRegister(registrationDto.CollegeName, university);
            var user = await _registrationRepositoryService.UserRegister(registrationDto.Username, registrationDto.Password, college);
            return user;

        }
    }
}
