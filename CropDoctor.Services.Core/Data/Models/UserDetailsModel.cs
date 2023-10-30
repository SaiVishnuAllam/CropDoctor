using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data.Models
{
    public class UserDetailsModel
    {
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("universityName")]
        public string UniversityName { get; set; }

        [BsonElement("collegeName")]
        public string CollegeName { get; set; }

        [BsonElement("isActive")]
        public bool? IsActive { get; set; }

        /*[BsonElement("userId")]
        public string? UserId { get; set; }*/
    }
}
