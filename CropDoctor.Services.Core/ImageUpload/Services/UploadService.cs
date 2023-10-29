using Azure.Storage.Blobs.Models;
using CropDoctor.Services.Core.ImageUpload.Contracts;
using CropDoctor.Services.Core.ImageUpload.Dtos;
using CropDoctor.Services.Core.ImageUpload.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepositoryService _uploadRepositoryService;

        public UploadService(IUploadRepositoryService uploadRepositoryService)
        {
            _uploadRepositoryService = uploadRepositoryService;
        }
        public async Task<ImageResponseDto> UploadImage(IFormFile image)
        {
            ImageResponseDto result =await _uploadRepositoryService.Upload(image);
            return result;
        }
    }
}
