using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperPublicacao : IMapperPublicacao
    {
        #region Properties

        readonly MapperComentario _mapperComentario = new MapperComentario();
        readonly List<PublicacaoDTO> _publicacaoDTOs = new List<PublicacaoDTO>();
        readonly MapperPublicacaoFoto _mapperPublicacaoFoto = new MapperPublicacaoFoto();

        #endregion

        #region methods

        public Publicacao MapperToEntity(PublicacaoDTO dto)
        {
            Publicacao obj = new Publicacao
            {
                Id = dto.Id,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                TipoCobranca = dto.TipoCobranca,
                Comentarios = _mapperComentario.MapperList(dto.Comentarios),
                PublicacaoFotos = _mapperPublicacaoFoto.MapperList(dto.PublicacaoFotos),
            };

            return obj;
        }

        public ICollection<PublicacaoDTO> MapperList(ICollection<Publicacao> objs)
        {
            foreach (var obj in objs)
            {
                PublicacaoDTO dto = new PublicacaoDTO
                {
                    Id = obj.Id,
                    Titulo = obj.Titulo,
                    Descricao = obj.Descricao,
                    Preco = obj.Preco,
                    TipoCobranca = obj.TipoCobranca,
                    Comentarios = _mapperComentario.MapperList(obj.Comentarios),
                    PublicacaoFotos = _mapperPublicacaoFoto.MapperList(obj.PublicacaoFotos),
                };

                _publicacaoDTOs.Add(dto);
            }

            return _publicacaoDTOs;
        }

        public PublicacaoDTO MapperToDTO(Publicacao obj)
        {
            PublicacaoDTO dto = new PublicacaoDTO
            {
                Id = obj.Id,
                Titulo = obj.Titulo,
                Descricao = obj.Descricao,
                Preco = obj.Preco,
                TipoCobranca = obj.TipoCobranca,
                Comentarios = _mapperComentario.MapperList(obj.Comentarios),
                PublicacaoFotos = _mapperPublicacaoFoto.MapperList(obj.PublicacaoFotos),
            };

            return dto;
        }

        #endregion
    }
}
