using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Dtos
{
    public class ImageResponseDto
    {
        public string? Status { get; set; }
        public bool Error { get; set; }
        public string? ImageUri { get; set; }
        public string? Name { get; set; }

    }
}
