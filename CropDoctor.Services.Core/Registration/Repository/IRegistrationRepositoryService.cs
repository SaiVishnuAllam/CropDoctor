using CropDoctor.Services.Core.Registration.Dtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Registration.Repository
{
    public interface IRegistrationRepositoryService
    {
        Task<ObjectId> UniversityRegister(string university);

        Task<ObjectId> CollegeRegister(string college, ObjectId universityId);

        Task<ObjectId> UserRegister(string username,  string password, string studId, string emaiul, ObjectId collegeId);
    }
}
