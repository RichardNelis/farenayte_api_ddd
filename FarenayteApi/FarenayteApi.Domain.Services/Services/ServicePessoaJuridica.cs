using System.Threading.Tasks;
using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServicePessoaJuridica : ServiceBase<PessoaJuridica>, IServicePessoaJuridica
    {
        private readonly IRepositoryPessoaJuridica _repository;

        public ServicePessoaJuridica(IRepositoryPessoaJuridica Repository)
            : base(Repository)
        {
            _repository = Repository;
        }

        public virtual async Task<PessoaJuridica> GetByIdFullAsync(int id)
        {
            return await _repository.GetByIdFullAsync(id);
        }
    }
}
