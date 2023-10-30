using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data.Models
{
    public class ResponseModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("imageName")]
        public string? ImageName { get; set; }

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [BsonElement("disease")]
        public string? Disease { get; set;}

        [BsonElement("userId")]
        public string? UserId { get; set;}

        [BsonElement("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [BsonElement("updatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
}
