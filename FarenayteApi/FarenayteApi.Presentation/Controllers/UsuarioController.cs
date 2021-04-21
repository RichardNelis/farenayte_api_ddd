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
            //dto.Id = AuthUser().Id;
            return Ok(await _applicationService.GetAllAsync());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] UsuarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.Add(dto);
                return Ok("Cadastro salvo com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UsuarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound("Não encontrado!");

                dto.Id = AuthUser().Id;

                _applicationService.Update(dto);
                return Ok("Cadastro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}