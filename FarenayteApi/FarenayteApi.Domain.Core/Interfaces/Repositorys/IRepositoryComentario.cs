using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryComentario : IRepositoryBase<Comentario>
    {
        Task<ICollection<Comentario>> GetByEsPublicacaoAsync(int esPublicacao);

        Task<Comentario> GetByIdWithPessoaFisicaAsync(int id);
    }
}
