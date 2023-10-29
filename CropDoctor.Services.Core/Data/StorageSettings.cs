using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Data
{
    public class StorageSettings
    {
        public string AccountUrl { get; set; }
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }

    }
}
