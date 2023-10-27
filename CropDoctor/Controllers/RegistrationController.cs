using CropDoctor.Services.Core.Core.Exceptions;
using CropDoctor.Services.Core.Registration.Contracts;
using CropDoctor.Services.Core.Registration.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CropDoctor.Service.Controllers
{
    [Authorize]
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<string>> Registration(RegistrationDto registrationDto)
        {
            if (registrationDto == null)
                throw new BadRequestException("Check the data such that everything is filled and have other that null value.");
            var result = await _registrationService.UserRegistration(registrationDto);
            if (result == null)
            {
                return NotFound("error");
            }
            return Ok($"User is registered with Id = {result}");
        }
    }
}
