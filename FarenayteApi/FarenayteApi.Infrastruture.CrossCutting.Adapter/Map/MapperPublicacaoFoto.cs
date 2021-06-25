using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperPublicacaoFoto : IMapperPublicacaoFoto
    {
        #region Properties

        readonly List<PublicacaoFoto> _publicacaoFotos = new List<PublicacaoFoto>();
        readonly List<PublicacaoFotoDTO> _publicacaoFotoDTOs = new List<PublicacaoFotoDTO>();

        #endregion

        #region methods

        public PublicacaoFoto MapperToEntity(PublicacaoFotoDTO dto)
        {
            PublicacaoFoto obj = new PublicacaoFoto
            {
                Id = dto.Id,
                EsPublicacao = dto.EsPublicacao,
                Foto = dto.Foto,
            };

            return obj;
        }

        public ICollection<PublicacaoFotoDTO> MapperList(ICollection<PublicacaoFoto> objs)
        {
            foreach (var obj in objs)
            {
                PublicacaoFotoDTO dto = new PublicacaoFotoDTO
                {
                    Id = obj.Id,
                    EsPublicacao = obj.EsPublicacao,
                    Foto = obj.Foto,
                };

                _publicacaoFotoDTOs.Add(dto);
            }

            return _publicacaoFotoDTOs;
        }

        public ICollection<PublicacaoFoto> MapperList(ICollection<PublicacaoFotoDTO> dtos)
        {
            foreach (var obj in dtos)
            {
                PublicacaoFoto publicacaoFoto = new PublicacaoFoto
                {
                    Id = obj.Id,
                    EsPublicacao = obj.EsPublicacao,
                    Foto = obj.Foto,
                };

                _publicacaoFotos.Add(publicacaoFoto);
            }

            return _publicacaoFotos;
        }

        public PublicacaoFotoDTO MapperToDTO(PublicacaoFoto obj)
        {
            PublicacaoFotoDTO dto = new PublicacaoFotoDTO
            {
                Id = obj.Id,
                EsPublicacao = obj.EsPublicacao,
                Foto = obj.Foto,
            };

            return dto;
        }

        #endregion
    }
}
