using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IApplicationServicePessoaJuridica _applicationService;
        private readonly IApplicationServicePessoaJuridicaFilter _applicationServiceFilter;

        public PessoaJuridicaController(IApplicationServicePessoaJuridica ApplicationService, IApplicationServicePessoaJuridicaFilter ApplicationServiceFilter)
        {
            _applicationService = ApplicationService;
            _applicationServiceFilter = ApplicationServiceFilter;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<ICollection<string>> Get()
        {            
            return Ok(_applicationServiceFilter.GetFilter());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationService.GetById(id));
        }

        // POST api/values
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

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] PessoaJuridicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

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