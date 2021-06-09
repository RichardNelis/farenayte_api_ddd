using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<ICollection<Comentario>> GetByEsPublicacaoAsync(int esPublicacao)
        {
            return await _repository.GetByEsPublicacaoAsync(esPublicacao);
        }

        public async Task<Comentario> GetByIdWithPessoaFisicaAsync(int id)
        {
            return await _repository.GetByIdWithPessoaFisicaAsync(id);
        }
    }
}
