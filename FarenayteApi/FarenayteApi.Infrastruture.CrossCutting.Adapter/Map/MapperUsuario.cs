using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperUsuario : IMapperUsuario
    {
        #region properties

        readonly List<UsuarioRequestDTO> usuarioDTOs = new List<UsuarioRequestDTO>();
        readonly MapperPessoaFisica _mapperPessoaFisica = new MapperPessoaFisica();

        #endregion

        #region methods

        public Usuario MapperToEntity(UsuarioRequestDTO dto)
        {
            Usuario obj = new Usuario
            {
                //Id = dto.Id,
                Email = dto.Email,
                Password = dto.Password,
                //PessoaFisica = _mapperPessoaFisica.MapperToEntity(dto.PessoaFisica)
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
                    //PessoaFisica = _mapperPessoaFisica.MapperToDTO(obj.PessoaFisica),
                };

                usuarioDTOs.Add(usuarioDTO);
            }

            return usuarioDTOs;
        }

        public UsuarioRequestDTO MapperToDTO(Usuario obj)
        {
            UsuarioRequestDTO dto = new UsuarioRequestDTO
            {
                //Id = obj.Id,
                Email = obj.Email,
                Password = obj.Password,
                //PessoaFisica = _mapperPessoaFisica.MapperToDTO(obj.PessoaFisica),
            };

            return dto;
        }

        #endregion
    }
}
