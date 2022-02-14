using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class ImagemController : BaseController
    {
        private readonly string _pathRoot;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImagemController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
            _pathRoot = Path.Combine(webHostEnvironment.ContentRootPath, "imagens/");
        }

        [HttpGet("{name}"), AllowAnonymous]
        public IActionResult Get(string name)
        {
            try
            {
                Byte[] b = System.IO.File.ReadAllBytes(_pathRoot + name);
                return File(b, "image/" + name.Split(".").Last());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<string> UploadedFileAsync(IFormFile file)
        {
            if (file != null)
            {
                using (FileStream filestream = System.IO.File.Create(_pathRoot + file.FileName))
                {
                    await file.CopyToAsync(filestream);
                    filestream.Flush();
                }
            }

            return file.FileName;
        }
    }
}