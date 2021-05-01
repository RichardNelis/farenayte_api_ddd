using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

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

        public PessoaJuridica GetByIdFull(int id)
        {
            return _repository.GetByIdFull(id);
        }
    }
}
