using FarenayteApi.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class BaseController : ControllerBase
{
    MessageDTO _message;

    public BaseController()
    {
        _message = new MessageDTO();
    }

    protected UsuarioDTO AuthUser()
    {
        UsuarioDTO authUser = new UsuarioDTO();
        authUser.Id = Int32.Parse(User.Claims.First().Value);
        return authUser;
    }

    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object value)
    {
        _message.Messages = (ICollection<string>)value;
        return new BadRequestObjectResult(_message);
    }
}