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
        private ActionResult GetById(int id)
        {
            return Ok(_applicationService.GetById(id));
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int esPublicacao)
        {
            return Ok(_applicationService.GetByEsPublicacao(esPublicacao));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.Add(dto);

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

                _applicationService.Update(dto);

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
        public ActionResult Delete(int id)
        {
            try
            {
                var dto = _applicationService.GetById(id);

                _applicationService.Remove(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Comentário excluído com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/resposta")]
        public ActionResult PutResposta([FromQuery] int tipo, [FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return NotFound();
                }

                _applicationService.Update(dto);

                MessageDTO message = new MessageDTO();

                if (tipo == 1) // add
                {
                    message.Messages = new List<string> { "Resposta salva com sucesso!" };
                }
                else if (tipo == 2) // update
                {
                    message.Messages = new List<string> { "Resposta alterada com sucesso!" };
                }
                else // delete
                {
                    message.Messages = new List<string> { "Resposta excluída com sucesso!" };
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
