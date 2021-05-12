using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        UsuarioResponseDTO Add(UsuarioDTO dto);

        UsuarioDTO GetById(int id);

        void Update(UsuarioDTO dto);

        void Dispose();
    }
}
