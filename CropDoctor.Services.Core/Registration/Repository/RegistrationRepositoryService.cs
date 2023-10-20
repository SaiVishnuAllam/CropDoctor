using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.Data.Models;
using CropDoctor.Services.Core.Registration.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Registration.Repository
{
    public class RegistrationRepositoryService : IRegistrationRepositoryService
    {
        private readonly MongoDbContext _context;

        public RegistrationRepositoryService()
        {
            _context = MongoDbContext.Instance;
        }

        public async Task<ObjectId> UniversityRegister(string university)
        {
            var Univer = await _context.University.Find(s => s.UniversityName == university).FirstOrDefaultAsync();
            if (Univer != null)
            {
                return Univer.Id;
            }
            var result = new UniversityModel
            {
                UniversityName = university,
            };
            await _context.University.InsertOneAsync(result);
            return result.Id;
        }

        public async Task<ObjectId> CollegeRegister(string college, ObjectId universityId)
        {
            var allCollege = await _context.College.Find(s => s.CollegeName == college).FirstOrDefaultAsync();
            if (allCollege != null)
            {
                return allCollege.Id;
            }
            var result = new CollegeModel
            {
                UniversityId = universityId,
                CollegeName = college
            };
            await _context.College.InsertOneAsync(result);
            return result.Id;
        }

        public async Task<ObjectId> UserRegister(string userName, string password, ObjectId collegeId)
        {
            var allUsers = await _context.User.Find(s => s.Username ==userName && s.Password == password).FirstOrDefaultAsync();
            if(allUsers != null)
            {
                return allUsers.Id;
            }
            var result = new UserModel
            {
                Username = userName,
                Password = password,
                CollegeId = collegeId,
                IsActive = true
            };
            await _context.User.InsertOneAsync(result);
            return result.Id;
        }
    }
}
