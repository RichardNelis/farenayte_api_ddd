using System.Threading.Tasks;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceAutorizacao
    {
        Task<UsuarioResponseDTO> ValidarAcesso(LoginDTO dto);

        void Dispose();
    }
}
