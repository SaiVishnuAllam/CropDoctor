using CropDoctor.Services.Core.ImageUpload.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Repository
{
    public interface IUploadRepositoryService
    {
        Task<ImageResponseDto> Upload(IFormFile image);
    }
}
