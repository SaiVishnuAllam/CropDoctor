﻿using MongoDB.Bson.Serialization.Attributes;
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
    }
}