using System.Collections.Generic;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceComentario
    {
        void Add(ComentarioDTO dto);

        ComentarioDTO GetById(int id);

        ICollection<ComentarioDTO> GetByEsPublicacao(int esPublicacao);
        
        void Update(ComentarioDTO dto);

        void RemoverResposta(int id);

        void Remove(int id);

        void Dispose();
    }
}