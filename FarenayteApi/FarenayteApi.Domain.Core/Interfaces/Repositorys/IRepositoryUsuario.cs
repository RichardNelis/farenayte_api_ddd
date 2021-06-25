using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Task UpdateAlterarSenhaAsync(int id, string password);

        Task<ICollection<Usuario>> GetByEmailAsync(string email);
    }
}
