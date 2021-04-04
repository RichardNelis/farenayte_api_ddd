using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServicePublicacao : ServiceBase<Publicacao>, IServicePublicacao
    {
        private readonly IRepositoryPublicacao _repository;

        public ServicePublicacao(IRepositoryPublicacao Repository)
            : base(Repository)
        {
            _repository = Repository;
        }
    }
}
