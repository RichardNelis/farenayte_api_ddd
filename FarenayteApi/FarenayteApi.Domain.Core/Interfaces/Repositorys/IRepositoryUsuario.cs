using System.Collections.Generic;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        ICollection<Usuario> GetByEmail(string email);
    }
}
