using FarenayteApi.Domain.Models;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Task UpdateAlterarSenhaAsync(int id, string password);

        Task<Usuario> GetByEmailAsync(string email);
    }
}
