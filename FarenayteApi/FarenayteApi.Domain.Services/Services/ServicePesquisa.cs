using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServicePesquisa : IDisposable, IServicePesquisa
    {
        private readonly IRepositoryPesquisa _repository;

        public ServicePesquisa(IRepositoryPesquisa Repository)            
        {
            _repository = Repository;
        }

        public virtual ICollection<PessoaJuridica> GetFilter(PessoaJuridica obj)
        {
            return _repository.GetFilter(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
