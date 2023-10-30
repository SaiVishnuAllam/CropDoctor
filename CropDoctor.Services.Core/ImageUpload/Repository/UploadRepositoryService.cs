using Azure.Storage.Blobs;
using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.Data.Models;
using CropDoctor.Services.Core.ImageUpload.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Repository
{
    public class UploadRepositoryService : IUploadRepositoryService
    {
        private readonly BlobContainerClient _container;

        public UploadRepositoryService(IOptions<StorageSettings> storageSettings)
        {
            var client = new BlobServiceClient(storageSettings.Value.ConnectionString);
            if(client != null)
            {
                _container = client.GetBlobContainerClient(storageSettings.Value.ContainerName);
            }
        }

        public async Task<ImageResponseDto> Upload(IFormFile image)
        {
            ImageResponseDto response = new ImageResponseDto();
            BlobClient blobClient = _container.GetBlobClient(image.FileName);
            response.Error = true;
            await using (Stream? data = image.OpenReadStream())
            {
                await blobClient.UploadAsync(data);
            }
            response.Status = $"File {image.FileName} added successfully";
            response.Error = false;
            response.ImageUri = blobClient.Uri.AbsoluteUri;
            response.Name = blobClient.Name;
            return response;
        }
    }
}
