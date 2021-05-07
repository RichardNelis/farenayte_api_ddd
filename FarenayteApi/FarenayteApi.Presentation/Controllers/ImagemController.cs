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
        private string _pathRoot;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ImagemController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
            if (!Directory.Exists(webHostEnvironment.ContentRootPath + "\\Imagens\\"))
            {
                Directory.CreateDirectory(webHostEnvironment.ContentRootPath + "\\Imagens\\");
            }

            _pathRoot = webHostEnvironment.ContentRootPath + "\\Imagens\\";
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public IActionResult Get(string name)
        {
            try
            {
                Byte[] b = System.IO.File.ReadAllBytes(_pathRoot + name);   // You can use your own method over here.         
                return File(b, "image/" + name.Split(".").Last());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<string> UploadedFileAsync(IFormFile file)
        {
            string nomeArquivo = String.Empty;

            if (file != null)
            {
                nomeArquivo = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Second}{DateTime.Now.Millisecond}_{file.FileName}";                               
                
                using (FileStream filestream = System.IO.File.Create(_pathRoot + nomeArquivo))
                {
                    String caminho = "\\Imagens\\" + nomeArquivo;
                    await file.CopyToAsync(filestream);
                    filestream.Flush();
                }
            }

            return nomeArquivo;
        }

        /*[HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> EnviaArquivo([FromForm] IFormFileCollection arquivos)
        {
            if (arquivos.Count > 0)
            {
                try
                {
                    for (int i = 0; i < arquivos.Count; i++)
                    {
                        using (FileStream filestream = System.IO.File.Create(_pathRoot + arquivos[i].FileName))
                        {
                            String caminho = "\\Imagens\\" + arquivos[i].FileName;
                            await arquivos[i].CopyToAsync(filestream);
                            filestream.Flush();
                        }
                    }

                    return Ok();
                }
                catch (Exception)
                {
                    for (int i = 0; i < arquivos.Count; i++)
                    {
                        System.IO.File.Delete(_pathRoot + arquivos[i].FileName);
                    }

                    return BadRequest();
                }
            }
            else
            {
                return Ok();
            }
        }*/
    }
}