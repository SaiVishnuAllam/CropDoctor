using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Authentication.Dtos
{
    public class RequestPaswordDto
    {
        public class RequestPasswordDto
        {
            [JsonProperty("id")]
            public string? Id { get; set; }

            [JsonProperty("userName")]
            public string UserName { get; set; }

            [JsonProperty("oldPassword")]
            public string? OldPassword { get; set; }

            [JsonProperty("newPassword")]
            public string? NewPassword { get; set; }

            [JsonProperty("otpCode")]
            public string? OtpCode { get; set; }

            [JsonProperty("changeType")]
            public string? ChangeType { get; set; }
        }
    }
}
