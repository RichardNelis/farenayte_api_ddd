﻿using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_applicationService.GetById(AuthUser().Id));
        }

        [HttpGet("{esUsuario}")]
        public ActionResult Get(int esUsuario)
        {
            return Ok(_applicationService.GetByIdFull(esUsuario));
        }

        [HttpPost]
        public ActionResult Post([FromBody] PessoaJuridicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                dto.EsPessoaFisica = AuthUser().Id;
                _applicationService.Add(dto);

                MessageDTO message = new MessageDTO();
                message.Messages = new List<string> { "Cadastro salvo com sucesso!" };

                return CreatedAtAction(nameof(Get), new { usuario = dto, message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] PessoaJuridicaDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                dto.EsPessoaFisica = AuthUser().Id;

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