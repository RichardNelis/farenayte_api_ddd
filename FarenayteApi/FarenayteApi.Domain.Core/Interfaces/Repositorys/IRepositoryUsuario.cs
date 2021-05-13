using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Task<ICollection<Usuario>> GetByEmailAsync(string email);
    }
}
