using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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

        [HttpGet, ActionName("GetAsync")]
        public async Task<IActionResult> GetAsync()
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

                return CreatedAtAction(nameof(GetAsync), responseDTO);
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

                MessageDTO message = new MessageDTO()
                {
                    Mensagem = "Cadastro atualizado com sucesso!"
                };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("password")]
        public async Task<IActionResult> PutAsync(UsuarioAlterarSenhaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                dto.Id = AuthUser().Id;

                await _applicationService.UpdatePasswordAsync(dto);

                MessageDTO message = new MessageDTO()
                {
                    Mensagem = "Senha atualizada com sucesso!"
                };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("recuperarsenha")]
        public async Task<IActionResult> RecuperarSenhaAsync(String email)
        {
            try
            {                
                await _applicationService.RecuperarSenhaAsync(email);

                MessageDTO message = new MessageDTO()
                {
                    Mensagem = "Senha atualizada com sucesso!"
                };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}