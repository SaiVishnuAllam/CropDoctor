using CropDoctor.Services.Core.Registration.Contracts;
using CropDoctor.Services.Core.Registration.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CropDoctor.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> Registration(RegistrationDto registrationDto)
        {
            var result = await _registrationService.UserRegistration(registrationDto);
            if (result == null)
            {
                return NotFound("error");
            }
            return Ok($"User is registered with Id = {result}");
        }
    }
}
