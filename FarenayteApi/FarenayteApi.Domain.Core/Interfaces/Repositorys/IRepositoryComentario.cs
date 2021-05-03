using System.Collections.Generic;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryComentario : IRepositoryBase<Comentario>
    {
        ICollection<Comentario> GetByEsPublicacao(int esPublicacao);
    }
}
