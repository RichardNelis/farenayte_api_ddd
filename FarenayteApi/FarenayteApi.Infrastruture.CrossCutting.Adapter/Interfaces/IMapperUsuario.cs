using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperUsuario
    {
        #region Mappers

        Usuario MapperToEntity(UsuarioRequestDTO UsuarioDTO);

        ICollection<UsuarioRequestDTO> MapperListUsuarios(ICollection<Usuario> Usuarios);

        UsuarioRequestDTO MapperToDTO(Usuario Usuario);

        #endregion
    }
}
