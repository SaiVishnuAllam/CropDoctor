using CropDoctor.Services.Core.Authentication.Contracts;
using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Core.Exceptions;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CropDoctor.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        

        [AllowAnonymous]
        [HttpPost]
        public async Task<string> Auth(UserDto userDto)
        {            
            if (userDto == null)
            {
                throw new UnauthorizedException("User Details are not entered, check once !!");
            }
            var result = await _authService.Authentication(userDto);
            return result;
        }
    }
}
