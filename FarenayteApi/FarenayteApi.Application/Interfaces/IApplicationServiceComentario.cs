using System.Collections.Generic;
using System.Threading.Tasks;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceComentario
    {
        Task AddAsync(ComentarioDTO dto);

        Task<ComentarioDTO> GetByIdAsync(int id);

        Task<ICollection<ComentarioDTO>> GetByEsPublicacaoAsync(int esPublicacao);
        
        Task UpdateAsync(ComentarioDTO dto);

        Task RemoverRespostaAsync(int id);

        Task RemoveAsync(int id);

        void Dispose();
    }
}