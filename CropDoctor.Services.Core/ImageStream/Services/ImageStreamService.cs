/*using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using CropDoctor.Services.Core.ImageStream.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CropDoctor.Services.Core.ImageStream.Dtos;
using System.Diagnostics;
using Microsoft.Azure.Storage.Blob;
using CropDoctor.Services.Core.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CropDoctor.Services.Core.ImageStream.Repository;

namespace CropDoctor.Services.Core.ImageStream.Services
{

    public class ImageStreamService : IImageStreamService
    {

        private readonly IImageStreamRepositoryService _imageStreamRepositoryService;

        public StorageSettings Settings { get; }

        public ImageStreamService(IImageStreamRepositoryService imageStreamRepositoryService)
        {
            _imageStreamRepositoryService = imageStreamRepositoryService;
        }


        public async Task<FileItemDto> UploadImage(Stream imageStream, string fileName, string fileType)
        {
            Stopwatch stopWatch = _imageStreamRepositoryService.GetStartStopWatchForDebug();

            CloudBlockBlob blockBlob = _imageStreamRepositoryService.GetCloudBlockBlob(fileName, "banner");

            if (fileType != null) blockBlob.Properties.ContentType = fileType;

            await blockBlob.UploadFromStreamAsync(imageStream).ConfigureAwait(false);

            FileItemDto fileItemDto = await _imageStreamRepositoryService.BuildUploadFileResults(stopWatch, blockBlob).ConfigureAwait(false);

            return fileItemDto;
        }


    }






}
*/