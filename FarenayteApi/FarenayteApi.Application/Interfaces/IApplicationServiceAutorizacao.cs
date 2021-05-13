using System.Threading.Tasks;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceAutorizacao
    {
        Task<LoginResponseDTO> ValidarAcessoAsync(LoginDTO dto);

        Task<LoginResponseDTO> GetByIdAsync(int id);

        void Dispose();
    }
}
