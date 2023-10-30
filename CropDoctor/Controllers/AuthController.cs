using CropDoctor.Services.Core.Authentication.Contracts;
using CropDoctor.Services.Core.Authentication.Dtos;
using CropDoctor.Services.Core.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static CropDoctor.Services.Core.Authentication.Dtos.RequestPaswordDto;

namespace CropDoctor.Service.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// API To Login
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedException"></exception>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Auth(UserDto userDto)
        {
            try
            {
                var result = await _authService.Authentication(userDto);
                return Ok(result);
            }
            catch (Exception ex) 
            {
               // Logger.LogError("MP-Admin-User-Login-Error", ex.Message);
                //string errorStrackTraceWithRequest = $"{JsonConvert.SerializeObject(UserDto)} \n ###*** \n {ex.StackTrace}";
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// API to register student details
        /// </summary>
        /// <param name="registrationDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Registration(RegistrationDto registrationDto)
        {

            var result = await _authService.UserRegistration(registrationDto);
            if (result == null)
            {
                return NotFound("error");
            }
            return Ok($"User is registered with Id = {result}");
        }

        /// <summary>
        /// API to reset password
        /// </summary>
        /// <param name="requestPasswordDto"></param>
        /// <returns></returns>
        [Route("change/password")]
        [HttpPost]
        public async Task<ActionResult> ResetPassword(RequestPasswordDto requestPasswordDto)
        {
            try
            {
                var result = await _authService.ResetPassword(requestPasswordDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //Logger.LogError("MP-Reset-Password-Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// API endpoint to verify the reset code provided to the user in email and to set a new password for the user
        /// </summary>
        /// <param name="requestPasswordDto"></param>
        /// <returns></returns>
        [Route("update/password")]
        [HttpPost]
        public async Task<ActionResult> UpdatePassword(RequestPasswordDto requestPasswordDto)
        {
            try
            {
                var result = await _authService.UpdatePassword(requestPasswordDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //Logger.LogError("MP-update-Password-Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
