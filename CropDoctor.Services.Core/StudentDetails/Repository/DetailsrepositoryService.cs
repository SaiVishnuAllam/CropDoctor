using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.StudentDetails.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.StudentDetails.Repository
{
    public class DetailsrepositoryService : IDetailsRepositoryService
    {
        private readonly MongoDbContext _context;

        public DetailsrepositoryService()
        {
            _context = MongoDbContext.Instance;
        }

        public async Task<DetailsDto> Details(string studentId)
        {
            var user = await _context.User.Find(s => s.Id == studentId).FirstOrDefaultAsync();
            if (user != null)
            { 
                var college = await _context.College.Find( s => s.Id  == user.CollegeId).FirstOrDefaultAsync();
                var university = await _context.University.Find( s => s.Id == college.UniversityId).FirstOrDefaultAsync();
                var count = await _context.Response.Find(s => s.UserId == studentId).CountDocumentsAsync();
                DetailsDto details = new DetailsDto()
                {
                    UserName = user.Username,
                    CollegeName = college.CollegeName,
                    UniversityName = university.UniversityName,
                    Count = count
                };
                return details;
            }
            else
            {
                return null;
            }
        }
    }
}
