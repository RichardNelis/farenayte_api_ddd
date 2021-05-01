using System.Threading.Tasks;
using FarenayteApi.Application.DTO.DTO;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceAutorizacao
    {
        LoginResponseDTO ValidarAcesso(LoginDTO dto);

        LoginResponseDTO GetById(int id);

        void Dispose();
    }
}
