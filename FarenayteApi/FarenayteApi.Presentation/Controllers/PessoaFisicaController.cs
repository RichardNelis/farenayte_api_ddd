using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IApplicationServicePessoaFisica _applicationService;

        public PessoaFisicaController(IApplicationServicePessoaFisica ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        /*[HttpGet]
        public ActionResult<ICollection<string>> Get()
        {
            return Ok(_applicationService.GetAll());
        }*/

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationService.GetById(id));
        }

        /*[HttpPost]
        public ActionResult Post([FromBody] PessoaFisicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.Add(dto);
                return Ok("Pessoa Fisica cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] PessoaFisicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.Update(dto);
                return Ok("Pessoa Fisica atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/    
    }
}