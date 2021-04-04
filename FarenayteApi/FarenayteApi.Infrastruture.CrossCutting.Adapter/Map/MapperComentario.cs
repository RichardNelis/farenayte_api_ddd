using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperComentario : IMapperComentario
    {
        #region Properties

        readonly List<Comentario> _comentarios = new List<Comentario>();
        readonly List<ComentarioDTO> _comentarioDTOs = new List<ComentarioDTO>();
        readonly MapperPessoaFisica _mapperPessoaFisica = new MapperPessoaFisica();

        #endregion

        #region methods

        public Comentario MapperToEntity(ComentarioDTO dto)
        {
            Comentario obj = new Comentario
            {
                Id = dto.Id,
                EsPublicacao = dto.EsPublicacao,
                EsPessoaFisica = dto.EsPessoaFisica,
                Rating = dto.Rating,
                ComentarioPF = dto.ComentarioPF,
                Resposta = dto.Resposta,
                PessoaFisica = _mapperPessoaFisica.MapperToEntity(dto.PessoaFisica)
            };

            return obj;
        }

        public ICollection<ComentarioDTO> MapperList(ICollection<Comentario> objs)
        {
            foreach (var obj in objs)
            {
                ComentarioDTO dto = new ComentarioDTO
                {
                    Id = obj.Id,
                    EsPublicacao = obj.EsPublicacao,
                    EsPessoaFisica = obj.EsPessoaFisica,
                    Rating = obj.Rating,
                    ComentarioPF = obj.ComentarioPF,
                    Resposta = obj.Resposta,
                    PessoaFisica = _mapperPessoaFisica.MapperToDTO(obj.PessoaFisica)
                };

                _comentarioDTOs.Add(dto);
            }

            return _comentarioDTOs;
        }

        public ICollection<Comentario> MapperList(ICollection<ComentarioDTO> dtos)
        {
            foreach (var dto in dtos)
            {
                Comentario obj = new Comentario
                {
                    Id = dto.Id,
                    EsPublicacao = dto.EsPublicacao,
                    EsPessoaFisica = dto.EsPessoaFisica,
                    Rating = dto.Rating,
                    ComentarioPF = dto.ComentarioPF,
                    Resposta = dto.Resposta,
                    PessoaFisica = _mapperPessoaFisica.MapperToEntity(dto.PessoaFisica)
                };

                _comentarios.Add(obj);
            }

            return _comentarios;
        }

        public ComentarioDTO MapperToDTO(Comentario obj)
        {
            ComentarioDTO dto = new ComentarioDTO
            {
                Id = obj.Id,
                EsPublicacao = obj.EsPublicacao,
                EsPessoaFisica = obj.EsPessoaFisica,
                Rating = obj.Rating,
                ComentarioPF = obj.ComentarioPF,
                Resposta = obj.Resposta,
                PessoaFisica = _mapperPessoaFisica.MapperToDTO(obj.PessoaFisica)
            };

            return dto;
        }

        #endregion
    }
}
