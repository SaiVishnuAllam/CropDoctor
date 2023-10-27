using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("collegeId")]
        public ObjectId CollegeId { get; set; }

        [BsonElement("username")]
        public string? Username { get; set;}

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("isActive")]
        public bool? IsActive { get; set; }

        [BsonElement("studentId")]
        public string? StudentID { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }


    }
}
