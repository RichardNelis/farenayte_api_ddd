using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_applicationService.GetByIdAsync(id));
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int esPublicacao)
        {
            return Ok(_applicationService.GetByEsPublicacaoAsync(esPublicacao));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.AddAsync(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Comentário salvo com sucesso!" };

                return CreatedAtAction(nameof(GetById), new { id = dto.Id }, new { comentario = dto, message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult PutComentario([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return NotFound();
                }

                _applicationService.UpdateAsync(dto);

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
        public ActionResult DeleteComentario(int id)
        {
            try
            {
                _applicationService.RemoveAsync(id);

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
        public ActionResult PutResposta([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return NotFound();
                }

                _applicationService.UpdateAsync(dto);

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
        public ActionResult DeleteResposta(int id)
        {
            try
            {
                _applicationService.RemoverRespostaAsync(id);

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
