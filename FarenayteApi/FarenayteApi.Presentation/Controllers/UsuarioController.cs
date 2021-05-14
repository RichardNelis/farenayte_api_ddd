using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IApplicationServiceUsuario _applicationService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public UsuarioController(IApplicationServiceUsuario ApplicationService, IWebHostEnvironment hostEnvironment)
        {
            _applicationService = ApplicationService;
            webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _applicationService.GetByIdAsync(AuthUser().Id));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromForm] string usuario, [FromForm] IFormFile file)
        {
            try
            {
                if (usuario == null)
                    return NotFound();

                UsuarioDTO dto = JsonConvert.DeserializeObject<UsuarioDTO>(usuario);

                if (file != null)
                {
                    await new ImagemController(webHostEnvironment).UploadedFileAsync(file);
                }

                UsuarioResponseDTO responseDTO = await _applicationService.AddAsync(dto);
                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Cadastro salvo com sucesso!" };

                return CreatedAtAction(nameof(Get), new { usuario = responseDTO, message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromForm] string usuario, [FromForm] IFormFile file)
        {
            try
            {
                if (usuario == null)
                    return NotFound();

                UsuarioDTO dto = JsonConvert.DeserializeObject<UsuarioDTO>(usuario);

                dto.Id = AuthUser().Id;

                if (file != null)
                {
                    await new ImagemController(webHostEnvironment).UploadedFileAsync(file);
                }
                
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