using CropDoctor.Services.Core.Data;
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

        public async Task Details(ObjectId studentId)
        {
            var user = await _context.User.Find(s => s.Id == studentId).FirstOrDefaultAsync();
            if (user != null)
            { 
                var college = await _context.College.Find( s => s.Id  == user.CollegeId).FirstOrDefaultAsync();
                var university = await _context.University.Find( s => s.Id == college.UniversityId).FirstOrDefaultAsync();
            }          
        }
    }
}
