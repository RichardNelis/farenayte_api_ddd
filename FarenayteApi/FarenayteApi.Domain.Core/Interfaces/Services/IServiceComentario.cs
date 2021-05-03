using System.Collections.Generic;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceComentario : IServiceBase<Comentario>
    {
        ICollection<Comentario> GetByEsPublicacao(int esPublicacao);
    }
}
