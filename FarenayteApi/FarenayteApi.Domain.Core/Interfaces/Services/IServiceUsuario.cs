using FarenayteApi.Domain.Models;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Task UpdateAlterarSenhaAsync(int id, string password);

        Task<Usuario> GetByEmailAsync(string email);
    }
}
