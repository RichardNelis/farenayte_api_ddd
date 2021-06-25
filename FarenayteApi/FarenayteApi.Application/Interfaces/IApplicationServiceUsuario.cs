using FarenayteApi.Application.DTO.DTO;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        Task<UsuarioResponseDTO> AddAsync(UsuarioDTO dto);

        Task<UsuarioResponseDTO> GetByIdAsync(int id);

        Task UpdateAsync(UsuarioDTO dto);

        Task UpdatePasswordAsync(UsuarioAlterarSenhaDTO dto);

        void Dispose();
    }
}
