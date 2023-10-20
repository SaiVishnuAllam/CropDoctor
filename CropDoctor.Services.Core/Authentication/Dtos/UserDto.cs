using Newtonsoft.Json;


namespace CropDoctor.Services.Core.Authentication.Dtos
{
    public class UserDto
    {

        [JsonProperty("userName")]
        public string? UserName { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("universityName")]
        public string? UniversityName { get; set; }

        [JsonProperty("collegeName")]
        public string? CollegeName { get; set; }

    }

}
