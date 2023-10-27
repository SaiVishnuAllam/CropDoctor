using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Authentication.Dtos
{
    public class LoginDto
    {

        [JsonProperty("accessToken")]
        public string? AccessToken { get; set; }

        [JsonProperty("tokenExpiryHours")]
        public int? TokenExpiryHours { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set;}

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("collegeName")]
        public string? CollegeName { get; set; }

        [JsonProperty("universityName")]
        public string? UniversityName { get; set; }
    }
}
