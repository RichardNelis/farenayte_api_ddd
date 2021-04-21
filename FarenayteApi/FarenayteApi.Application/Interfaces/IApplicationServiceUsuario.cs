using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDTO dto);

        Task<ICollection<UsuarioDTO>> GetAllAsync();

        Task<ICollection<UsuarioDTO>> GetByEmail(string email);

        void Update(UsuarioDTO dto);

        void Dispose();
    }
}
