using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServicePessoaFisica : ServiceBase<PessoaFisica>, IServicePessoaFisica
    {
        private readonly IRepositoryPessoaFisica _repository;

        public ServicePessoaFisica(IRepositoryPessoaFisica Repository)
            : base(Repository)
        {
            _repository = Repository;
        }
    }
}
