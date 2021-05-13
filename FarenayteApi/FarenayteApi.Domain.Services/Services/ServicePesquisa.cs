using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServicePesquisa : IDisposable, IServicePesquisa
    {
        private readonly IRepositoryPesquisa _repository;

        public ServicePesquisa(IRepositoryPesquisa Repository)            
        {
            _repository = Repository;
        }

        public virtual async Task<ICollection<PessoaJuridica>> GetFilterAsync(PessoaJuridica obj)
        {
            return await _repository.GetFilterAsync(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
