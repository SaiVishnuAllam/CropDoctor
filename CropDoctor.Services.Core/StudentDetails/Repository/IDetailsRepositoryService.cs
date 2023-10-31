using CropDoctor.Services.Core.StudentDetails.Dtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.StudentDetails.Repository
{
    public interface IDetailsRepositoryService
    {
        Task<DetailsDto> Details(string studentId);
    }
}
