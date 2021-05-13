using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryComentario : IRepositoryBase<Comentario>
    {
        Task<ICollection<Comentario>> GetByEsPublicacaoAsync(int esPublicacao);
    }
}
