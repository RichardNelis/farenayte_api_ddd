using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario
    {
        void Add(Usuario obj);
        
        Task<ICollection<Usuario>> GetAll();

        Task<ICollection<Usuario>> GetByEmail(string email);

void Update(Usuario obj);

        void Dispose();
    }
}
