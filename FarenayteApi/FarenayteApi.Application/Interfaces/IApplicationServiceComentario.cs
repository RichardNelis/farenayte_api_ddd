using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceComentario
    {
        void Add(ComentarioDTO dto);

        ComentarioDTO GetById(int id);

        ICollection<ComentarioDTO> GetAll();

        void Update(ComentarioDTO dto);

        void Remove(ComentarioDTO dto);

        void Dispose();
    }
}