using CropDoctor.Services.Core.ImageUpload.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDoctor.Service.Controllers
{
    [Route("api/ImageUpload")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public ImageUploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }
        [HttpPost]
        [Route("SingleImage")]
        public async Task<IActionResult> SingleImageUpload(IFormFile image)
        {
            var result = await _uploadService.UploadImage(image);
            return Ok(result);
        }
    }
}
