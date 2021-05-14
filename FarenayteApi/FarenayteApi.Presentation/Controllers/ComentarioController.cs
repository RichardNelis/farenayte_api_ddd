using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteAPI.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class ComentarioController : BaseController
    {
        private readonly IApplicationServiceComentario _applicationService;

        public ComentarioController(IApplicationServiceComentario ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpGet("{id}"), ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _applicationService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int esPublicacao)
        {
            return Ok(await _applicationService.GetByEsPublicacaoAsync(esPublicacao));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                await _applicationService.AddAsync(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Comentário salvo com sucesso!" };

                return CreatedAtAction(nameof(GetByIdAsync), new { id = dto.Id }, new { comentario = dto, message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutComentarioAsync([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return NotFound();
                }

                await _applicationService.UpdateAsync(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Comentário salvo com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentarioAsync(int id)
        {
            try
            {
                await _applicationService.RemoveAsync(id);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Comentário excluído com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("resposta")]
        public async Task<IActionResult> PutRespostaAsync([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return NotFound();
                }

                await _applicationService.UpdateAsync(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Resposta salva com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("resposta/{id}")]
        public async Task<IActionResult> DeleteRespostaAsync(int id)
        {
            try
            {
                await _applicationService.RemoverRespostaAsync(id);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Resposta excluída com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
