using System.Collections.Generic;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceComentario
    {
        void Add(ComentarioDTO dto);

        ComentarioDTO GetById(int id);

        ICollection<ComentarioDTO> GetByEsPublicacao(int esPublicacao);

        ICollection<ComentarioDTO> GetAll();

        void Update(ComentarioDTO dto);

        void RemoverResposta(int id);

        void Remove(ComentarioDTO dto);

        void Dispose();
    }
}