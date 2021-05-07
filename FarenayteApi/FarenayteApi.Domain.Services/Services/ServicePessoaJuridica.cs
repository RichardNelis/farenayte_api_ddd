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

        public virtual PessoaJuridica GetByIdFull(int id)
        {
            return _repository.GetByIdFull(id);
        }
    }
}
