
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using CropDoctor.Services.Core.Entry.Contracts;
using Microsoft.AspNetCore.Authorization;
using CropDoctor.Services.Core.Core.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace CropDoctor.Service.Controllers
{
    [Authorize]
    [Route("api/entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryServices _entryServices;

        public EntryController(IEntryServices entryServices)
        {
            _entryServices = entryServices;
        }
        [HttpPost]
        [Route("post")]     
        public async Task<IActionResult> EntryUpload(IFormFile image, string plantName, string plantPart, string plantDisease)
        {
            if (plantName == null || plantPart == null || plantDisease == null || image == null)
                throw new BadRequestException("Please check the inputs such that everything is filled !! ");
            else
            {
                var result = await _entryServices.InsertImage(image, plantName, plantPart, plantDisease);
                return Ok($"Image uploaded successfully and Id ={result} ");
            }            
        }
        [HttpGet]
        [Route("get")]     
        public async Task<IActionResult> EntryDisplay(string id)
        {
            if (id.IsNullOrEmpty())
                throw new BadRequestException("Check the id such that it is not empty or null");
            else
            {
                var image = await _entryServices.DisplayImage(id);

                return File(image.ImageData, "image/jpeg");
            }
        }
    }
}
