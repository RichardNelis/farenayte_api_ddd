using System.Collections.Generic;
using FarenayteApi.Domain.Core.Interfaces.Repositorys;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Services.Services
{
    public class ServiceComentario : ServiceBase<Comentario>, IServiceComentario
    {
        private readonly IRepositoryComentario _repository;

        public ServiceComentario(IRepositoryComentario Repository)
            : base(Repository)
        {
            _repository = Repository;
        }

        public virtual ICollection<Comentario> GetByEsPublicacao(int esPublicacao)
        {
            return _repository.GetByEsPublicacao(esPublicacao);
        }
    }
}
