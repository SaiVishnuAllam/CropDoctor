using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Authentication.Repository
{
    public class AuthRepositoryService : IAuthRepositoryService
    {
        private readonly MongoDbContext _context;

        public AuthRepositoryService()
        {
            _context = MongoDbContext.Instance;
        }

        public async Task<UserDetailsModel> AuthVerify(UserDto userDto)
        {
            
            
            var pipeline = new[]
            {
                new BsonDocument("$match",
                new BsonDocument
                {
                    { "username", userDto.UserName },
                    { "password", userDto.Password }
                }),
                new BsonDocument("$lookup",
                new BsonDocument
                {
                    { "from", "CollegeList" },
                    { "localField", "collegeId" },
                    { "foreignField", "_id" },
                    { "as", "collegeName" }
                }),
                new BsonDocument("$lookup",
                new BsonDocument
                {
                    { "from", "UniversityList" },
                    { "localField", "collegeName.universityId" },
                    { "foreignField", "_id" },
                    { "as", "universityName" }
                }),
                new BsonDocument("$unwind",
                new BsonDocument
                {
                    { "path", "$collegeName" },
                    { "preserveNullAndEmptyArrays", true }
                }),
                new BsonDocument("$unwind",
                new BsonDocument
                {
                    { "path", "$universityName" },
                    { "preserveNullAndEmptyArrays", true }
                }),
                new BsonDocument("$project",
                new BsonDocument
                {
                    { "userName", "$username" },
                    { "password", "$password" },
                    { "universityName", "$universityName.universityName" },
                    { "collegeName", "$collegeName.collegeName" },
                    { "isActive", "$isActive" }
                })
            };


            var query = pipeline.ToJson();
            var data = await _context.User.Aggregate<BsonDocument>(pipeline).ToListAsync().ConfigureAwait(false);
            var list = data.ConvertAll(BsonTypeMapper.MapToDotNetValue);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            var userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDetailsModel>>(json).FirstOrDefault();
            return userList;

            
        }
    }
    
}
