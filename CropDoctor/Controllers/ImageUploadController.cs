using CropDoctor.Services.Core.ImageUpload.Contracts;
using CropDoctor.Services.Core.ImageUpload.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDoctor.Service.Controllers
{
    [Authorize]
    [Route("api/image")]
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
        /// <summary>
        /// API to upload Image to azure storage
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> SingleImageUpload(IFormFile image)
        {
            try
            {
                var result = await _uploadService.UploadImage(image);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// API to save Image URL to DB
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveSingleImage(ImageSaveDto details)
        {
            try
            {
                await _saveImageService.SaveImage(details);
                return Ok("Image Saved in DB");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
