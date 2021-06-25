using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceComentario
    {
        Task AddAsync(ComentarioDTO dto);

        Task<ComentarioDTO> GetByIdAsync(int id);

        Task<ComentarioDTO> GetByIdWithPessoaFisicaAsync(int id);

        Task<ICollection<ComentarioDTO>> GetByEsPublicacaoAsync(int esPublicacao);

        Task UpdateAsync(ComentarioDTO dto);

        Task RemoverRespostaAsync(int id);

        Task RemoveAsync(int id);

        void Dispose();
    }
}