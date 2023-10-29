/*using CropDoctor.Services.Core.ImageStream.Dtos;
using Microsoft.Azure.Storage.Blob;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageStream.Repository
{
    public interface IImageStreamRepositoryService
    {
        Task<FileItemDto> BuildUploadFileResults(Stopwatch sp, CloudBlockBlob blockBlob);
        Stopwatch GetStartStopWatchForDebug();
        CloudBlockBlob GetCloudBlockBlob(string fileFullPath, string containerName);
        //Task OptimizedUploadStreamAsync(CloudBlockBlob blockBlob, Stream fileStream, StorageSettings settings);
    }
}
*/