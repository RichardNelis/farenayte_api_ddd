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
        public async Task<ActionResult> Post([FromBody] LoginDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                LoginResponseDTO login = await _applicationService.ValidarAcesso(dto);
                login.Token = await Token.GenerateToken(login);

                return Ok(login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize()]
        [HttpPost("validaracesso")]
        public async Task<ActionResult> Post()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}