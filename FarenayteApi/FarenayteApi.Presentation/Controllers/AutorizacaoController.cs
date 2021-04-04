﻿using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Presentation.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizacaoController : ControllerBase
    {
        private readonly IApplicationServiceAutorizacao _applicationService;

        public AutorizacaoController(IApplicationServiceAutorizacao ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound();

                LoginDTO login = await _applicationService.ValidarAcesso(usuarioDTO);
                var token = await Token.GenerateToken(login);

                return Ok(new { usuario = login, token });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}