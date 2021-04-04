using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperAutorizacao : IMapperAutorizacao
    {
        #region properties

        readonly List<UsuarioDTO> _usuarioDTOs = new List<UsuarioDTO>();

        #endregion

        #region methods

        public Usuario MapperToEntity(UsuarioDTO dto)
        {
            Usuario obj = new Usuario
            {
                Id = dto.Id,
                Email = dto.Email,
                Password = dto.Password,                
            };

            return obj;
        }

        public ICollection<UsuarioDTO> MapperListUsuarios(ICollection<Usuario> objs)
        {
            foreach (var obj in objs)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO
                {
                    Id = obj.Id,
                    Email = obj.Email,
                    Password = obj.Password,
                };

                _usuarioDTOs.Add(usuarioDTO);
            }

            return _usuarioDTOs;
        }

        public UsuarioDTO MapperToDTO(Usuario obj)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = obj.Id,
                Email = obj.Email,
                Password = obj.Password,
            };

            return usuarioDTO;
        }

        public LoginDTO MapperToDTO(PessoaFisica obj)
        {
            LoginDTO dto = new LoginDTO
            {
                Id = obj.EsUsuario,
                NomeCompleto = obj.NomeCompleto,
                Photo = obj.Photo,
                EsPessoaJuridica = obj.PessoaJuridica.EsPessoaFisica,
            };

            return dto;
        }

        #endregion
    }
}
