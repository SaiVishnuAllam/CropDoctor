using CropDoctor.Services.Core.Core.Exceptions;
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
            if (university == ObjectId.Empty)
                throw new InternalServerErrorException("Unable to add or get university to Database");
            var college = await _registrationRepositoryService.CollegeRegister(registrationDto.CollegeName, university);
            if (college == ObjectId.Empty)
                throw new InternalServerErrorException("Unable to add or get college to Database");
            var user = await _registrationRepositoryService.UserRegister(registrationDto.Username, registrationDto.Password, registrationDto.StudentId, registrationDto.Email, college);
            if (user == ObjectId.Empty)
                throw new InternalServerErrorException("Unable to add or get User Details to Database");
            return user;

        }
    }
}
