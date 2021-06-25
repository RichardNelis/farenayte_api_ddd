using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Task UpdateAlterarSenhaAsync(int id, string password);

        Task<ICollection<Usuario>> GetByEmailAsync(string email);
    }
}
