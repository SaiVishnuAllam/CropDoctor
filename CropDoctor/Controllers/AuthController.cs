using CropDoctor.Services.Core.Authentication.Contracts;
using CropDoctor.Services.Core.Authentication.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<IActionResult> Auth(UserDto userDto)
        {            
            IActionResult response = Unauthorized();
            if (userDto != null)
            {
                 var result = await _authService.Authentication(userDto);

                if (result == "university")
                    response = Unauthorized($"{userDto.UniversityName} is not registered in this program");
                else if (result == "college")
                    response = Unauthorized($"{userDto.CollegeName} is not registered under {userDto.UniversityName}");
                else if (result == "login")
                    response = Unauthorized($"{userDto.UserName} is not registered, Check the UserName and Password Again");
                else if (result == "invalid")
                    response = Unauthorized("Access is not granted to user, please contact the your incharge.");
                else
                    response = Ok(result);
            }

            return response;
        }
    }
}
