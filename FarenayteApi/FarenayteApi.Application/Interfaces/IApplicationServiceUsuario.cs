using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        UsuarioResponseDTO Add(UsuarioDTO dto);

        //Task<ICollection<UsuarioDTO>> GetAllAsync();

        UsuarioDTO GetById(int id);

        //Task<ICollection<UsuarioDTO>> GetByEmail(string email);

        void Update(UsuarioDTO dto);

        void Dispose();
    }
}
