using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Task<ICollection<Usuario>> GetByEmailAsync(string email);
    }
}
