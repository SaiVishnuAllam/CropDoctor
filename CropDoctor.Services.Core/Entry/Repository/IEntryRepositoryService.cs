using CropDoctor.Services.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Entry.Repository
{
    public interface IEntryRepositoryService
    {
        Task<string> Insert(EntryModel imageData);

        Task<EntryModel> Display(string id);
    }
}
