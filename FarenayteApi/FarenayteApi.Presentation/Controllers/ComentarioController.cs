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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_applicationService.GetByEsPublicacao(id));
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
        public ActionResult Put([FromBody] ComentarioDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return NotFound();
                }

                _applicationService.Update(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Comentário atualizado com sucesso!" };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _repository.FindId(id);

                if (data == null)
                {
                    _message.Messages.Add("Comentário não encontrado!");
                    return NotFound(_message);
                }

                await _repository.Remove(data);

                _message.Messages.Add("Comentário excluído com sucesso!");
                return Ok(_message);
            }
            catch (Exception)
            {
                _message.Messages.Add("Erro ao deletar o comentário!");
                return BadRequest(_message);
            }
        }*/

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_applicationService.GetAll());
        }

        [HttpGet("{esPublicacao}")]
        public ActionResult Get(int esPublicacao)
        {
            return Ok(_applicationService.GetByEsPublicacao(esPublicacao));
        }
    }
}
