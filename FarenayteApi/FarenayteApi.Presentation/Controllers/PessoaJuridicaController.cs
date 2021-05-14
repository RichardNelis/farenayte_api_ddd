using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class PessoaJuridicaController : BaseController
    {
        private readonly IApplicationServicePessoaJuridica _applicationService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public PessoaJuridicaController(IApplicationServicePessoaJuridica ApplicationService, IWebHostEnvironment hostEnvironment)
        {
            _applicationService = ApplicationService;
            webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_applicationService.GetByIdAsync(AuthUser().Id));
        }

        [HttpGet("{esUsuario}")]
        public ActionResult Get(int esUsuario)
        {
            return Ok(_applicationService.GetByIdFullAsync(esUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] string usuario, [FromForm] IFormFile file, [FromForm] List<IFormFile> files)
        {
            try
            {
                ImagemController imagemController = new ImagemController(webHostEnvironment);

                if (usuario == null)
                    return NotFound();

                PessoaJuridicaDTO dto = JsonConvert.DeserializeObject<PessoaJuridicaDTO>(usuario);

                if (file != null)
                {
                    await imagemController.UploadedFileAsync(file);
                }

                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        await imagemController.UploadedFileAsync(files[i]);
                    }
                }

                dto.EsPessoaFisica = AuthUser().Id;
                await _applicationService.AddAsync(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Cadastro salvo com sucesso!" };

                return CreatedAtAction(nameof(Get), new { usuario = dto, message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromForm] string usuario, [FromForm] IFormFile file, [FromForm] List<IFormFile> files)
        {
            try
            {
                ImagemController imagemController = new ImagemController(webHostEnvironment);

                if (usuario == null)
                    return NotFound();

                PessoaJuridicaDTO dto = JsonConvert.DeserializeObject<PessoaJuridicaDTO>(usuario);

                if (file != null)
                {
                    await imagemController.UploadedFileAsync(file);
                }

                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        await imagemController.UploadedFileAsync(files[i]);
                    }
                }

                dto.EsPessoaFisica = AuthUser().Id;

                await _applicationService.UpdateAsync(dto);
                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Cadastro atualizado com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}