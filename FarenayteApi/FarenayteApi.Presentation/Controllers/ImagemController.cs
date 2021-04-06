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
        public static IWebHostEnvironment _environment;

        public ImagemController(IWebHostEnvironment environment)
        {
            _environment = environment;

            if (!Directory.Exists(_environment.ContentRootPath + "\\Imagens\\"))
            {
                Directory.CreateDirectory(_environment.ContentRootPath + "\\Imagens\\");
            }

            _pathRoot = _environment.ContentRootPath + "\\Imagens\\";
        }

        [HttpGet("{name}")]
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

        [HttpPost]
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
        }
    }
}