/*using Azure.Storage.Blobs;
using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.ImageStream.Dtos;
using CropDoctor.Services.Core.ImageStream.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace CropDoctor.Services.Core.ImageStream.Repository
{
    public class ImageStreamRepositoryService : IImageStreamRepositoryService
    {
        private readonly ILogger<ImageStreamService> _logger;
        private readonly CloudBlobClient _blobClient;

        public StorageSettings Settings { get; }

        public ImageStreamRepositoryService(IOptions<StorageSettings> settings, ILogger<ImageStreamService> logger)
        {
            _logger = logger;
            Settings = settings.Value;
            string storageConnectionString = Settings.ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<FileItemDto> BuildUploadFileResults(Stopwatch sp, CloudBlockBlob blockBlob)
        {
            if (Settings.IsDebugMode)
            {
                await blockBlob.FetchAttributesAsync().ConfigureAwait(false);
            }
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blockBlob.Uri);
            string relativePathUrl = $"{blobUriBuilder.BlobContainerName}/{blobUriBuilder.BlobName}";
            FileItemDto fileItemDto = new FileItemDto()
            {
                ContentType = blockBlob.Properties.ContentType,
                Name = blockBlob.Name,
                SizeInMB = Settings.IsDebugMode ? string.Format("{0:f2}MB", blockBlob.Properties.Length / (1024.0 * 1024.0)) : "N/A",
                Url = relativePathUrl,//blockBlob.Uri.AbsoluteUri,
                BlobUploadCostInSeconds = sp == null ? "N/A" : string.Format("{0:f2}s", sp.ElapsedMilliseconds / 1000.0)
            };

            return fileItemDto;
        }
        public Stopwatch GetStartStopWatchForDebug()
        {
            Stopwatch stopWatch = null;
            if (Settings.IsDebugMode)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }

            return stopWatch;
        }

        public CloudBlockBlob GetCloudBlockBlob(string fileFullPath, string containerName)
        {
            containerName = string.IsNullOrWhiteSpace(containerName) ? Settings.ContainerName : containerName;
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);

            string fileName = fileFullPath.Substring(fileFullPath.LastIndexOf('/') + 1);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            return blockBlob;
        }

        *//*public static async Task OptimizedUploadStreamAsync(this CloudBlockBlob blockBlob, Stream fileStream, StorageSettings settings)
        {
            StorageSettings.BlobRequestOption optionsSettings = settings.BlobRequestOptions;
            int backOffPeriodInSeconds = optionsSettings?.BackOffPeriodInSeconds ?? 2;
            TimeSpan backOffPeriod = TimeSpan.FromSeconds(backOffPeriodInSeconds);
            int retryCount = optionsSettings?.RetryCount ?? 1;

            BlobRequestOptions options = new BlobRequestOptions
            {
                ParallelOperationThreadCount = optionsSettings?.ParallelOperationThreadCount ?? 1,
                DisableContentMD5Validation = optionsSettings?.StoreBlobContentMD5 ?? true,
                StoreBlobContentMD5 = optionsSettings?.StoreBlobContentMD5 ?? false,
                RetryPolicy = new ExponentialRetry(backOffPeriod, retryCount),
            };

            blockBlob.StreamWriteSizeInBytes = 256 * 1024; //256 k

            await blockBlob.UploadFromStreamAsync(fileStream, null, options, null);
        }*//*
    }
}

*/