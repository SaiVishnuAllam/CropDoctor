using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data.Models
{
    public class EntryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("imageData")]
        public byte[] ImageData { get; set; }

        [BsonElement("plantName")]
        public string PlantName { get; set; }

        [BsonElement("plantPart")]
        public string PlantPart { get; set; }

        [BsonElement("diseases")]
        public string Diseases { get; set; }
    }
}
