using CropDoctor.Services.Core.ImageUpload.Contracts;
using CropDoctor.Services.Core.ImageUpload.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDoctor.Service.Controllers
{
    [Route("api/ImageUpload")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;
        private readonly ISaveImageService _saveImageService;

        public ImageUploadController(IUploadService uploadService, ISaveImageService saveImageService)
        {
            _uploadService = uploadService;
            _saveImageService = saveImageService;
        }
        [HttpPost]
        [Route("SingleImage")]
        public async Task<IActionResult> SingleImageUpload(IFormFile image)
        {
            var result = await _uploadService.UploadImage(image);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveImage")]
        public async Task<IActionResult> SaveSingleImage(ImageSaveDto details)
        {
            await _saveImageService.SaveImage(details);
            return Ok("Image Saved in DB");
        }
    }
}
