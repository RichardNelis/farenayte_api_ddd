using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAsync([FromQuery] PesquisaRequestDTO data)
        {
            try
            {
                var list = await _applicationService.GetFilterAsync(data);

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

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok();
        }
    }
}