using CropDoctor.Services.Core.StudentDetails.Contracts;
using CropDoctor.Services.Core.StudentDetails.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.StudentDetails.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly IDetailsRepositoryService _detailsRepositoryService;

        public DetailsService(IDetailsRepositoryService detailsRepositoryService)
        {
            _detailsRepositoryService = detailsRepositoryService;
        }

        public async Task GetDetails(ObjectId studentId)
        {
            await _detailsRepositoryService.Details(studentId);
        }
    }
}
