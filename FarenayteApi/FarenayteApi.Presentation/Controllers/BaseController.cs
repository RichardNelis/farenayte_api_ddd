using FarenayteApi.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Linq;

public abstract class BaseController : ControllerBase
{
    protected AutenticadoDTO AuthUser()
    {
        return new AutenticadoDTO
        {
            Id = Int32.Parse(User.Claims.First().Value)
        };
    }

    public override CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, [ActionResultObjectValue] object value)
    {
        ResultDTO result = new ResultDTO();
        result.Data = value;
        result.Mensagem = MessageDTO.MensagensRetorno(MessageDTO.TiposMensagens.MensagemIncluidoSucesso).Mensagem;

        return base.CreatedAtAction(actionName, routeValues, result);
    }

    public override UnauthorizedResult Unauthorized()
    {
        _ = MessageDTO.MensagensRetorno(MessageDTO.TiposMensagens.MensagemDinamica, mensagem: "Usuário não autenticado!");
        return base.Unauthorized();
    }

    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object value)
    {
        return base.BadRequest(MessageDTO.MensagensRetorno(MessageDTO.TiposMensagens.MensagemDinamica, mensagem: value.ToString()));
    }

    public NotFoundObjectResult NotFound()
    {
        return base.NotFound(MessageDTO.MensagensRetorno(MessageDTO.TiposMensagens.MensagemDinamica, mensagem: "Não encontrado!"));
    }

}