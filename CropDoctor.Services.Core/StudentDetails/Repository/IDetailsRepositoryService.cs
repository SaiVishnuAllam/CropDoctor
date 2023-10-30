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
        Task Details(ObjectId studentId);
    }
}
