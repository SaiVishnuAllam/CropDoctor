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
using static CropDoctor.Services.Core.Authentication.Dtos.RequestPaswordDto;

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
                    { "isActive", "$isActive" },
                    {"id", "$_id" }
                })
            };


            var query = pipeline.ToJson();
            var data = await _context.User.Aggregate<BsonDocument>(pipeline).ToListAsync().ConfigureAwait(false);
            var list = data.ConvertAll(BsonTypeMapper.MapToDotNetValue);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            var userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDetailsModel>>(json).FirstOrDefault();
            return userList;
          
        }

        public async Task<ObjectId> UniversityRegister(string university)
        {
            var universityName = await _context.University.Find(s => s.UniversityName == university).FirstOrDefaultAsync().ConfigureAwait(false);
            if (universityName is not null)
            {
                return universityName.Id;
            }
            var result = new UniversityModel
            {
                UniversityName = university,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = true
            };
            await _context.University.InsertOneAsync(result);
            return result.Id;
        }

        public async Task<ObjectId> CollegeRegister(string college, ObjectId universityId)
        {
            var allCollege = await _context.College.Find(s => s.CollegeName == college).FirstOrDefaultAsync().ConfigureAwait(false);
            if (allCollege is not null)
            {
                return allCollege.Id;
            }

            var result = new CollegeModel
            {
                UniversityId = universityId,
                CollegeName = college,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = true
            };
            await _context.College.InsertOneAsync(result);
            return result.Id;
        }

        public async Task<ObjectId> UserRegister(string userName, string password, string studId, string email, ObjectId collegeId)
        {
            var User = await _context.User.Find(s => s.Username == userName && s.Password == password).FirstOrDefaultAsync().ConfigureAwait(false);

            if (User != null)
            {
                return User.Id;
            }

            if (User is null)
            {
                var result = new UserModel
                {
                    Username = userName,
                    Password = password,
                    CollegeId = collegeId,
                    StudentID = studId,
                    Email = email,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsActive = true
                };
                await _context.User.InsertOneAsync(result);
                return result.Id;
            }
            return User.Id;
        }

        /*public async Task<User> GetUserByUserName(string userName)
        {
            User user = await _userRepositoryService.GetUserByUserName(userName);
            return user;
            
        }*/
        public async Task<UserModel> GetUserByUserName(string userName)
        {
            try
            {
                var filter = Builders<UserModel>.Filter.Where(x => x.Username == userName);
                UserModel user = await _context.User.Find(filter).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception occured while fetching user details in GetUserByUserName Method" + ex.Message);
            }
        }

        public async Task UpdateUserPassword(RequestPasswordDto requestPasswordDto)
        {
            FilterDefinition<UserModel> filterDefinition = Builders<UserModel>.Filter.Eq(x => x.Id, requestPasswordDto.Id);
            UserModel user = await _context.User.Find(filterDefinition).FirstOrDefaultAsync().ConfigureAwait(false);
            if (user != null)
            {
                UpdateDefinition<UserModel> updateDefinition = Builders<UserModel>.Update
                  .Set(x => x.Password, requestPasswordDto.NewPassword);
                var updateResult = await _context.User.UpdateOneAsync(filterDefinition, updateDefinition);
            }
            
        }

        public async Task<OtpVerification> VerifyOtp(string userName, string otpCode)
        {
            try
            {
                var otpVerification = await _context.OtpVerification.Find(x => x.UserName == userName && x.Code == otpCode).FirstOrDefaultAsync();

                return otpVerification;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("exception occured During otp verification", ex.Message));
            }
        }

        public async Task UpdateNewPassword(string userName, string newPassword)
        {
            try
            {
                var user = await GetUserByUserName(userName) ?? throw new Exception("User not found.");
                FilterDefinition<UserModel> filterDefinition = Builders<UserModel>.Filter.Eq(x => x.Id, user.Id);
                UserModel users = await _context.User.Find(filterDefinition).FirstOrDefaultAsync().ConfigureAwait(false);
                if (users != null)
                {
                    UpdateDefinition<UserModel> updateDefinition = Builders<UserModel>.Update
                      .Set(x => x.Password, newPassword);
                    var updateResult = await _context.User.UpdateOneAsync(filterDefinition, updateDefinition);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An Exception occured while updating user password", ex.Message));
            }
        }
    }

}
