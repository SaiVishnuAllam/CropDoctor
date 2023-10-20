using CropDoctor.Services.Core.Data.Models;
using CropDoctor.Services.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

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
            return image.Id;
        }

        public async Task<EntryModel> Display(string id)
        {
            return await _context.Collection.Find(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
