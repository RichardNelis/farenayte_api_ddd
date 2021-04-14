using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperAutorizacao : IMapperAutorizacao
    {
        #region properties
        
        readonly List<UsuarioRequestDTO> _usuarioDTOs = new List<UsuarioRequestDTO>();

        #endregion

        #region methods

        public Usuario MapperToEntity(UsuarioRequestDTO dto)
        {
            Usuario obj = new Usuario
            {
                Id = dto.Id,
                Email = dto.Email,
                Password = dto.Password,                
            };

            return obj;
        }

        public ICollection<UsuarioRequestDTO> MapperListUsuarios(ICollection<Usuario> objs)
        {
            foreach (var obj in objs)
            {
                UsuarioRequestDTO usuarioDTO = new UsuarioRequestDTO
                {
                    //Id = obj.Id,
                    Email = obj.Email,
                    Password = obj.Password,
                };

                _usuarioDTOs.Add(usuarioDTO);
            }

            return _usuarioDTOs;
        }

        public UsuarioRequestDTO MapperToDTO(Usuario obj)
        {
            UsuarioRequestDTO usuarioDTO = new UsuarioRequestDTO
            {
                //Id = obj.Id,
                Email = obj.Email,
                Password = obj.Password,
            };

            return usuarioDTO;
        }

        public UsuarioResponseDTO MapperToDTO(PessoaFisica obj)
        {
            UsuarioResponseDTO dto = new UsuarioResponseDTO
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
