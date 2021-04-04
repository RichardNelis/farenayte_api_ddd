using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicacaoController : ControllerBase
    {
        private readonly IApplicationServicePublicacao _applicationService;

        public PublicacaoController(IApplicationServicePublicacao ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<ICollection<string>> Get()
        {
            return Ok(_applicationService.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationService.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] PublicacaoDTO dto)
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

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] PublicacaoDTO dto)
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
        }

        // DELETE api/values/5
        /*[HttpDelete()]
        public ActionResult Delete([FromBody] PublicacaoDTO PublicacaoDTO)
        {
            try
            {
                if (PublicacaoDTO == null)
                    return NotFound();

                _applicationServicePublicacao.Remove(PublicacaoDTO);
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}