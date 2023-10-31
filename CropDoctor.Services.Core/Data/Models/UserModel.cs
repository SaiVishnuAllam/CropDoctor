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
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("collegeId")]
        public string CollegeId { get; set; }

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

        [BsonElement("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [BsonElement("updatedOn")]
        public DateTime? UpdatedOn { get; set; }


    }
}
