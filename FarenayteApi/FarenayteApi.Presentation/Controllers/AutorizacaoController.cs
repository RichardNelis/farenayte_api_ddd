using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Presentation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizacaoController : BaseController
    {
        private readonly IApplicationServiceAutorizacao _applicationService;

        public AutorizacaoController(IApplicationServiceAutorizacao ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Post([FromBody] LoginDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                LoginResponseDTO login = await _applicationService.ValidarAcessoAsync(dto);
                login.Token = await Token.GenerateToken(login);

                MessageDTO message = new MessageDTO
                {
                    Mensagem = "Bem-vindo(a) " + login.NomeCompleto
                };

                return Ok(new { usuario = login, message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize()]
        [HttpPost("validaracesso")]
        public async Task<IActionResult> Post()
        {
            try
            {
                LoginResponseDTO login = await _applicationService.GetByIdAsync(AuthUser().Id);
                login.Token = await Token.GenerateToken(login);

                MessageDTO message = new MessageDTO
                {
                    Mensagem = "Bem-vindo(a) novamente " + login.NomeCompleto
                };

                return Ok(new { usuario = login, message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}