using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data.Models
{
    public class CollegeModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("universityId")]
        public string UniversityId { get; set; }

        [BsonElement("collegeName")]
        public string? CollegeName { get; set; }

        [BsonElement("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [BsonElement("updatedOn")]
        public DateTime? UpdatedOn { get; set; }

        [BsonElement("isActive")]
        public bool? IsActive { get; set; }
    }
}
