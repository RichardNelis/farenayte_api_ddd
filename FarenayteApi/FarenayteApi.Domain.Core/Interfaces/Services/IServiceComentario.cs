using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceComentario : IServiceBase<Comentario>
    {
        Task<ICollection<Comentario>> GetByEsPublicacaoAsync(int esPublicacao);

        Task<Comentario> GetByIdWithPessoaFisicaAsync(int id);
    }
}
