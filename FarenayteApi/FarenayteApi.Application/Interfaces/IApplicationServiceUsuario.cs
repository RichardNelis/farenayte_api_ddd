using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<UsuarioResponseDTO> AddAsync(UsuarioDTO dto);

        Task<UsuarioDTO> GetByIdAsync(int id);

        Task UpdateAsync(UsuarioDTO dto);

        void Dispose();
    }
}
