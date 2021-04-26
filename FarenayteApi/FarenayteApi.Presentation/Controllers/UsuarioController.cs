using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IApplicationServiceUsuario _applicationService;

        public UsuarioController(IApplicationServiceUsuario ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<string>>> Get()
        {            
            return Ok(await _applicationService.GetById(AuthUser().Id));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] UsuarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                UsuarioResponseDTO responseDTO = _applicationService.Add(dto);
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
        public ActionResult Put([FromBody] UsuarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                dto.Id = AuthUser().Id;

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