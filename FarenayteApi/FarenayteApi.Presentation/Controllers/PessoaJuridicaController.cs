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
            return Ok(_applicationService.GetById(AuthUser().Id));
        }

        [HttpGet("{esUsuario}")]
        public ActionResult Get(int esUsuario)
        {
            return Ok(_applicationService.GetByIdFull(esUsuario));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] string usuario, [FromForm] IFormFile file, [FromForm] IFormCollection files)
        {
            try
            {
                ImagemController imagemController = new ImagemController(webHostEnvironment);

                if (usuario == null)
                    return NotFound();

                PessoaJuridicaDTO dto = JsonConvert.DeserializeObject<PessoaJuridicaDTO>(usuario);

                if (file != null)
                {
                    dto.Logo = await imagemController.UploadedFileAsync(file);
                }

                if (files.Files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        PublicacaoFotoDTO fotoDTO = new PublicacaoFotoDTO();
                        fotoDTO.Foto = await imagemController.UploadedFileAsync(files.Files[i]);

                        dto.Publicacao.PublicacaoFotos.Add(fotoDTO);
                    }
                }

                dto.EsPessoaFisica = AuthUser().Id;
                _applicationService.Add(dto);

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
        public async Task<ActionResult> PutAsync([FromForm] string usuario, [FromForm] IFormFile file, [FromForm] IFormCollection files)
        {
            try
            {
                ImagemController imagemController = new ImagemController(webHostEnvironment);

                if (usuario == null)
                    return NotFound();

                PessoaJuridicaDTO dto = JsonConvert.DeserializeObject<PessoaJuridicaDTO>(usuario);

                if (file != null)
                {
                    dto.Logo = await imagemController.UploadedFileAsync(file);
                }

                if (files.Files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        PublicacaoFotoDTO fotoDTO = new PublicacaoFotoDTO();
                        fotoDTO.Foto = await imagemController.UploadedFileAsync(files.Files[i]);

                        dto.Publicacao.PublicacaoFotos.Add(fotoDTO);
                    }
                }

                dto.EsPessoaFisica = AuthUser().Id;

                _applicationService.Update(dto);
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