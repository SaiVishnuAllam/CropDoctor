/*using CropDoctor.Services.Core.Data;
using CropDoctor.Services.Core.ImageStream.Contracts;
using CropDoctor.Services.Core.ImageStream.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CropDoctor.Service.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageStreamController : ControllerBase
    {
        private readonly IOptions<StorageSettings> _storageSettings;
        private readonly IImageStreamService _imageStreamService;

        public ImageStreamController(IOptions<StorageSettings> storageSettings, IImageStreamService imageStreamService)
        {
            _storageSettings = storageSettings;
            _imageStreamService = imageStreamService;
        }

        [HttpPost]
        [Route("upload")]

        public async Task<ActionResult<FileUploadResultDto>> ImageUpload(IFormFile formFile)
        {

            FileUploadResultDto result = new FileUploadResultDto
            {
                UploadedImage = new FileItemDto()
            };
            try
            {
                if (formFile != null)
                {

                    string fileType = Path.GetExtension(formFile.FileName).Replace(".", "");
                    string fileName = string.Format("{0}.{1}", Guid.NewGuid(), fileType);
                    //image url return

                    using Stream fileStream = formFile.OpenReadStream();
                    FileItemDto fileItemDto = await _imageStreamService.UploadImage(fileStream, fileName, formFile.ContentType).ConfigureAwait(false);
                    string imageUrl = fileItemDto.Url;
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        result.UploadedImage.Url = imageUrl;
                        result.Message = "Image Uploaded Successfully";
                    }
                    else
                    {
                        //result.Result = "Error";
                        result.Message = "Upload failed.. please try again.";
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = $"Error uploading the image: {ex.Message}";
                return StatusCode(500, result); // HTTP 500 for server error
            }
        }

    }
}
*/