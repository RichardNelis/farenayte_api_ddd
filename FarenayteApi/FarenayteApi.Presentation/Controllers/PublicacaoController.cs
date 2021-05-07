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

        [HttpGet]
        public ActionResult<ICollection<string>> Get()
        {
            return Ok(_applicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationService.GetById(id));
        }
    }
}