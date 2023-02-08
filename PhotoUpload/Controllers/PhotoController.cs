using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhotoUpload.Inrefaces;
using PhotoUpload.Models;

namespace PhotoUpload.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        public PhotoController(IPhotoService photoService) 
        {
            _photoService = photoService;
        }

        [HttpGet]
        public string GetText()
        {
            return "test text";
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<Photo>> AddPhoto(IFormFile file)
        {
            var result = await _photoService.UploadAsync(file);
            if(result.Error is not null)
            {
                return BadRequest(result.Error.Message);
            }

            Photo photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
            };

            return Ok(photo);
        }

    }
}
