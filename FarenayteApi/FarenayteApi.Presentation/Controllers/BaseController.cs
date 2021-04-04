using FarenayteApi.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

public abstract class BaseController : ControllerBase
{
    protected UsuarioDTO AuthUser()
    {
        UsuarioDTO authUser = new UsuarioDTO();
        authUser.Id = Int32.Parse(User.Claims.First().Value);
        return authUser;
    }
}