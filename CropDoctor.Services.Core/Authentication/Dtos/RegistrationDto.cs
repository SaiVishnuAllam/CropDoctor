using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Authentication.Dtos
{
    public class RegistrationDto
    {
        [JsonProperty("universityName")]
        public string? UniversityName { get; set; }

        [JsonProperty("collegeName")]
        public string? CollegeName { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("studentId")]
        public string? StudentId { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}
