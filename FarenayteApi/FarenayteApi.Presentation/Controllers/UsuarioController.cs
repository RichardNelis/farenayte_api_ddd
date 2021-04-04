﻿using FarenayteApi.Application.DTO.DTO;
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
            return Ok(await _applicationService.GetAllAsync());
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioDTO dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _applicationService.Add(dto);
                return Ok("Cadastrado com sucesso");
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
                    return NotFound();

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