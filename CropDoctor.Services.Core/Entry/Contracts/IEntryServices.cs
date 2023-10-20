using CropDoctor.Services.Core.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Entry.Contracts
{
    public  interface IEntryServices
    {
        Task<string> InsertImage(IFormFile image, string plantName, string plantPart, string plantDisease);
        Task<EntryModel> DisplayImage(string id);
    }
}
