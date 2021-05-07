using System.Collections.Generic;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        ICollection<Usuario> GetByEmail(string email);
    }
}
