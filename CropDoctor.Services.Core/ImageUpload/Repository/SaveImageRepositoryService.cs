using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.Data.Models;
using CropDoctor.Services.Core.ImageUpload.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.ImageUpload.Repository
{
    public class SaveImageRepositoryService : ISaveImageRepositoryService
    {
        private readonly MongoDbContext _context;

        public SaveImageRepositoryService()
        {
            _context = MongoDbContext.Instance;
           
        }
        public async Task Save(ImageSaveDto imageSaveDto)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                ImageName = imageSaveDto.ImageName,
                ImageUrl = imageSaveDto.ImageUrl,
                Disease = imageSaveDto.Disease,
                UserId = imageSaveDto.UserId
            };
        
            /*responseModel.ImageName = imageSaveDto.ImageName;
            responseModel.ImageUrl = imageSaveDto.ImageUrl;
            responseModel.Disease = imageSaveDto.Disease;
            responseModel.UserId = imageSaveDto.UserId;*/
            
            await _context.Response.InsertOneAsync(responseModel);
        }
    }
}
