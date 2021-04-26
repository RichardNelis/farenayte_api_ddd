using FarenayteApi.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class BaseController : ControllerBase
{
    protected AutenticadoDTO AuthUser()
    {
        AutenticadoDTO authUser = new AutenticadoDTO();
        authUser.Id = Int32.Parse(User.Claims.First().Value);
        return authUser;
    }

    public override UnauthorizedResult Unauthorized()
    {
        MessageDTO message = FormatMessageResult("Usuário não autenticado!");
        return base.Unauthorized();
    }

    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object value)
    {
        MessageDTO message = FormatMessageResult(value);
        return base.BadRequest(message);
    }

    public NotFoundObjectResult NotFound()
    {
        MessageDTO message = FormatMessageResult("Não encontrado!");
        return base.NotFound(message);
    }

    private MessageDTO FormatMessageResult(object value)
    {
        MessageDTO message = new MessageDTO();

        if (value.GetType() == typeof(string))
        {
            message.Messages = value.ToString().Split('|');
        }
        else
        {
            message.Messages = (ICollection<string>)value;
        }

        return message;
    }
}