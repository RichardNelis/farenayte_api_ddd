using FarenayteApi.Application.DTO.DTO;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceAutorizacao
    {
        Task<LoginResponseDTO> ValidarAcessoAsync(LoginDTO dto);

        Task<LoginResponseDTO> GetByIdAsync(int id);

        void Dispose();
    }
}
