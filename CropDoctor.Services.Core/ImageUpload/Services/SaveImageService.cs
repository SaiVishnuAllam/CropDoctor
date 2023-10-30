using Azure.Storage.Blobs.Models;
using CropDoctor.Services.Core.ImageUpload.Contracts;
using CropDoctor.Services.Core.ImageUpload.Dtos;
using CropDoctor.Services.Core.ImageUpload.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Services
{
    public class SaveImageService : ISaveImageService
    {
        private readonly ISaveImageRepositoryService _saveImageRepositoryService;

        public SaveImageService(ISaveImageRepositoryService saveImageRepositoryService)
        {
            _saveImageRepositoryService = saveImageRepositoryService;
        }
        public async Task SaveImage(ImageSaveDto imageDto)
        {
            await _saveImageRepositoryService.Save(imageDto);
        }
    }
}
