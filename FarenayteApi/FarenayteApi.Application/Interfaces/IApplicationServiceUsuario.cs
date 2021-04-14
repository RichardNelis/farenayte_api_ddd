using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioRequestDTO dto);

        Task<ICollection<UsuarioRequestDTO>> GetAllAsync();

        Task<ICollection<UsuarioRequestDTO>> GetByEmail(string email);

        void Update(UsuarioRequestDTO dto);

        void Dispose();
    }
}
