using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperComentario
    {
        #region Interfaces Mappers

        Comentario MapperToEntity(ComentarioDTO ComentarioDTO);

        ICollection<ComentarioDTO> MapperList(ICollection<Comentario> Comentarios);

        ICollection<Comentario> MapperList(ICollection<ComentarioDTO> ComentarioDTOs);

        ComentarioDTO MapperToDTO(Comentario Comentario);

        #endregion
    }
}
