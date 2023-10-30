using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.StudentDetails.Contracts
{
    public interface IDetailsService
    {
        Task GetDetails(ObjectId studentId);
    }
}
