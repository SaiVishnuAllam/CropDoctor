using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
