using CropDoctor.Services.Core.Data.Models;
using CropDoctor.Services.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using CropDoctor.Services.Core.Core.Exceptions;

namespace CropDoctor.Services.Core.Entry.Repository
{
    public class EntryRepositoryService : IEntryRepositoryService
    {
        private readonly MongoDbContext _context;

        public EntryRepositoryService()
        {
            _context = MongoDbContext.Instance;
        }

        public async Task<string> Insert(EntryModel image)
        {
            await _context.Collection.InsertOneAsync(image);
            if (image.Id == null)
                throw new NotFoundException("Data is not stored successfully. Please try again to upload data.");
            else
                return image.Id;
        }

        public async Task<EntryModel> Display(string id)
        {
            var result = await _context.Collection.Find(s => s.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            if (result ==null)

                
                throw new NotFoundException($"Data with the Id = {id} is not found");
            else
                return result;
        }
    }
}
