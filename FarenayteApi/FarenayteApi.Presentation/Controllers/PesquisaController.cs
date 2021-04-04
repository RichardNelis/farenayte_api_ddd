using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class PesquisaController : BaseController
    {
        private readonly IApplicationServicePesquisa _applicationService;

        public PesquisaController(IApplicationServicePesquisa ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpGet("filter")]
        public ActionResult<ICollection<string>> Get([FromQuery] PesquisaDTO data)
        {
            return Ok(_applicationService.GetFilter(data));
        }
    }
}