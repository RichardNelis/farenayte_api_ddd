using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public ActionResult Get([FromQuery] PesquisaRequestDTO data)
        {
            try
            {
                var list = _applicationService.GetFilter(data);

                if (list.Count == 0)
                {
                    return BadRequest("Nenhuma publicação encontrada!");
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest("Houve um erro!");
            }
        }
    }
}