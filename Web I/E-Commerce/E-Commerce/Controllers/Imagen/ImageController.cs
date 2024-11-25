using E_Commerce.Domain.Imagen;
using E_Commerce.Domain.Repository.Imagen;
using E_Commerce.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace E_Commerce.Controllers.Imagen
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IImageRepository _imageRepository;

        public ImageController(IConfiguration configuration, IImageRepository imageRepository)
        {
            _configuration = configuration;
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var imageId = 0;
            var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = Path.GetFileName(fileContent.FileName);
            var randomFileName = Guid.NewGuid().ToString() + Path.GetRandomFileName();
            var folderPath = _configuration["ApplicationFilesPath"];

            var filePath = folderPath + randomFileName;

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);

                Image img = new Image()
                {
                    FechaSubida = DateTime.Now,
                    Path = filePath,
                    Temporal = true,
                    FileName = fileName
                };
                await _imageRepository.CreateAsync(img);

                imageId = img.ImagenId;
            }

            return Ok(imageId);
        }

        [HttpGet]
        [Route("{imageId}")]
        public async Task<IActionResult> GetImage(int imageId)
        {
            Image img = await _imageRepository.FindByIdAsync(imageId);
            if (img == null)
            {
                return NotFound();
            }
            byte[] imageContent = System.IO.File.ReadAllBytes(img.Path);
            return File(imageContent, GetMimeType(img.FileName));
        }

        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
