using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;

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
    }
}
