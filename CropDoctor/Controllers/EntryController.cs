
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using CropDoctor.Services.Core.Entry.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CropDoctor.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryServices _entryServices;

        public EntryController(IEntryServices entryServices)
        {
            _entryServices = entryServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EntryUpload(IFormFile image, string plantName, string plantPart, string plantDisease)
        {
            var result = await _entryServices.InsertImage(image, plantName, plantPart, plantDisease);
            return Ok($"Image uploaded successfully and Id ={result} ");
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> EntryDisplay(string id)
        {

            var image = await _entryServices.DisplayImage(id);

            return File(image.ImageData, "image/jpeg") ;
        }
    }
}
