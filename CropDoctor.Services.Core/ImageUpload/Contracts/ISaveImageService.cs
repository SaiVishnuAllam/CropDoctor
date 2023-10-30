using CropDoctor.Services.Core.ImageUpload.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Contracts
{
    public interface ISaveImageService
    {
        Task SaveImage(ImageSaveDto imageSaveDto);

    }
}
