using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperUsuario : IMapperUsuario
    {
        #region properties

        readonly List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
        readonly MapperPessoaFisica _mapperPessoaFisica = new MapperPessoaFisica();

        #endregion

        #region methods

        public Usuario MapperToEntity(UsuarioDTO dto)
        {
            Usuario obj = new Usuario
            {
                Id = dto.Id,
                Email = dto.Email,
                Password = dto.Password,
                PessoaFisica = _mapperPessoaFisica.MapperToEntity(dto.PessoaFisica)
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
                    PessoaFisica = _mapperPessoaFisica.MapperToDTO(obj.PessoaFisica),
                };

                usuarioDTOs.Add(usuarioDTO);
            }

            return usuarioDTOs;
        }

        public UsuarioDTO MapperToDTO(Usuario obj)
        {
            UsuarioDTO dto = new UsuarioDTO
            {
                Id = obj.Id,
                Email = obj.Email,
                Password = obj.Password,
                PessoaFisica = _mapperPessoaFisica.MapperToDTO(obj.PessoaFisica),
            };

            return dto;
        }

        public UsuarioResponseDTO MapperToDTOResponse(Usuario obj)
        {
            UsuarioResponseDTO dto = new UsuarioResponseDTO
            {
                Email = obj.Email,
                PessoaFisica = _mapperPessoaFisica.MapperToDTOResponse(obj.PessoaFisica),
            };

            return dto;
        }

        #endregion
    }
}
