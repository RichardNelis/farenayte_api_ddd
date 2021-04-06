using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class ImagemController : BaseController
    {
        String pathRoot;
        public static IWebHostEnvironment _environment;

        public ImagemController(IWebHostEnvironment environment)
        {
            _environment = environment;

            if (!Directory.Exists(_environment.ContentRootPath + "\\Imagens\\"))
            {
                Directory.CreateDirectory(_environment.ContentRootPath + "\\Imagens\\");
            }

            pathRoot = _environment.ContentRootPath + "\\Imagens\\";
        }

        [HttpGet]
        public IEnumerable<IActionResult> Get()
        {
            List<FileContentResult> files = new List<FileContentResult>();
            string[] images = Directory.GetFiles(pathRoot, "*");

            for (int i = 0; i < images.Length; i++)
            {
                Byte[] b = System.IO.File.ReadAllBytes(pathRoot + images[i]);   // You can use your own method over here.         
                files.Add(File(b, "image/" + images[i].Split(".")[1]));
            }

            return files;
        }

        public IActionResult Get(String name)
        {
            Byte[] b = System.IO.File.ReadAllBytes(pathRoot + name);   // You can use your own method over here.         
            return File(b, "image/" + name.Split(".")[1]);
        }

        [HttpPost]
        public async Task<bool> EnviaArquivo([FromForm] IFormFileCollection arquivos)
        {
            if (arquivos.Count > 0)
            {
                try
                {
                    for (int i = 0; i < arquivos.Count; i++)
                    {
                        using (FileStream filestream = System.IO.File.Create(pathRoot + arquivos[i].FileName))
                        {
                            String caminho = "\\Imagens\\" + arquivos[i].FileName;
                            await arquivos[i].CopyToAsync(filestream);
                            filestream.Flush();
                        }
                    }

                    return true;
                }
                catch (Exception)
                {
                    for (int i = 0; i < arquivos.Count; i++)
                    {
                        System.IO.File.Delete(pathRoot + arquivos[i].FileName);
                    }

                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}