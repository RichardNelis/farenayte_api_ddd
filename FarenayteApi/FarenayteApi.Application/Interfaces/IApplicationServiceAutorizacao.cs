using System.Threading.Tasks;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceAutorizacao
    {
        Task<LoginDTO> ValidarAcesso(UsuarioDTO usuarioDTO);

        void Dispose();
    }
}
