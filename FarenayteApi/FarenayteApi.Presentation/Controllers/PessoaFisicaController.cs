using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarenayteApi.Presentation.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IApplicationServicePessoaFisica _applicationService;

        public PessoaFisicaController(IApplicationServicePessoaFisica ApplicationService)
        {
            _applicationService = ApplicationService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_applicationService.GetById(AuthUser().Id));
        }
    }
}