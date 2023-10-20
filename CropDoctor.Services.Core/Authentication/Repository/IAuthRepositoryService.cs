using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Authentication.Repository
{
    public interface IAuthRepositoryService
    {
        Task<UserDetailsModel> AuthVerify(UserDto userDto);
    }
}
