using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Dtos
{
    public class ImageSaveDto
    {
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonProperty("disease")]
        public string? Disease {  get; set; }

        [JsonProperty("imageName")]
        public string? ImageName { get; set; }
    }
}
