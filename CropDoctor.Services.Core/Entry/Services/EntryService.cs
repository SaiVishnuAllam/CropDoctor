using CropDoctor.Services.Core.Data.Models;
using CropDoctor.Services.Core.Entry.Contracts;
using CropDoctor.Services.Core.Entry.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Entry.Services
{
    public class EntryServices : IEntryServices
    {
        private readonly IEntryRepositoryService _entryRepositoryService;

        public EntryServices(IEntryRepositoryService entryRepositoryService)
        {
            _entryRepositoryService = entryRepositoryService;
        }

        public async Task<string> InsertImage(IFormFile image, string plantName, string plantPart, string plantDisease)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                var imageData = new EntryModel()
                {
                    ImageData = memoryStream.ToArray(),
                    PlantName = plantName,
                    PlantPart = plantPart,
                    Diseases = plantDisease
                };

                return await _entryRepositoryService.Insert(imageData);

            }
        }

        public async Task<EntryModel> DisplayImage(string id)
        {
            return await _entryRepositoryService.Display(id);

        }

    }
}
