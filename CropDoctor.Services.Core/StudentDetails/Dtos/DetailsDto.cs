using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.StudentDetails.Dtos
{
    public class DetailsDto
    {
        [JsonProperty("userName")]
        public string? UserName { get; set; }

        [JsonProperty("collegeName")]
        public string? CollegeName { get; set; }

        [JsonProperty("universityName")]
        public string? UniversityName { get; set; }

        [JsonProperty("count")]
        public long? Count { get; set; }
    }
}
