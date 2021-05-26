using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Task UpdateAlterarSenhaAsync(int id, string password);

        Task<ICollection<Usuario>> GetByEmailAsync(string email);
    }
}
