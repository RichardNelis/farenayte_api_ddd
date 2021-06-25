using FarenayteApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Domain.Core.Interfaces.Services
{
    public interface IServiceComentario : IServiceBase<Comentario>
    {
        Task<ICollection<Comentario>> GetByEsPublicacaoAsync(int esPublicacao);

        Task<Comentario> GetByIdWithPessoaFisicaAsync(int id);
    }
}
