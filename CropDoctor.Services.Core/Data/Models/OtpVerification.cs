using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data.Models
{
    public class OtpVerification
    {
        public OtpVerification()
        {
            SmsVerified = true;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("userId")]
        public string? UserId { get; set; }

        [BsonElement("userName")]
        public string? UserName { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("isVerified")]
        public bool IsVerified { get; set; }

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("code")]
        public string? Code { get; set; }

        [BsonElement("retriedCount")]
        public int RetriedCount { get; set; }

        [BsonElement("messageId")]
        public string? MessageId { get; set; }

        [BsonElement("sendStatus")]
        public string? SendStatus { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("otpCount")]
        public int OTPCount { get; set; }
        public DateTime LastRetriedAt { get; set; }

        [BsonElement("provider")]
        public string? Provider { get; set; }

        [BsonElement("updatedOn")]
        public DateTime UpdatedOn { get; set; }

        [BsonElement("smsVerified")]
        public bool SmsVerified { get; set; }

        [BsonElement("Type")]
        public string? ChangeType { get; set; }
    }
}
