using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class PessoaJuridicaController : BaseController
    {
        private readonly IApplicationServicePessoaJuridica _applicationService;

        public PessoaJuridicaController(IApplicationServicePessoaJuridica ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationService.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] PessoaJuridicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.Add(dto);
                return Ok("Pessoa juridica cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] PessoaJuridicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                dto.Id = AuthUser().Id;

                _applicationService.Update(dto);
                return Ok("Pessoa Juridica atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}