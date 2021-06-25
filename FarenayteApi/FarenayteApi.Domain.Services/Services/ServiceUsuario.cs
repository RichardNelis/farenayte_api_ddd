using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repository;

        public ServiceUsuario(IRepositoryUsuario Repository)
            : base(Repository)
        {
            _repository = Repository;
        }

        public virtual async Task<ICollection<Usuario>> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
        }

        public virtual async Task UpdateAlterarSenhaAsync(int id, string password)
        {
            await _repository.UpdateAlterarSenhaAsync(id, password);
        }
    }
}
