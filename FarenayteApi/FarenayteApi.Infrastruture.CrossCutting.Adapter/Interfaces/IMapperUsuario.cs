using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperUsuario
    {
        #region Mappers

        Usuario MapperToEntity(UsuarioDTO UsuarioDTO);

        ICollection<UsuarioDTO> MapperListUsuarios(ICollection<Usuario> Usuarios);

        UsuarioDTO MapperToDTO(Usuario Usuario);

        #endregion
    }
}
