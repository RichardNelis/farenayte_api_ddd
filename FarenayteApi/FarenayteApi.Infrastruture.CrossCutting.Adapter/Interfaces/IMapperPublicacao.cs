using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperPublicacao
    {
        #region Interfaces Mappers
        
        Publicacao MapperToEntity(PublicacaoDTO PublicacaoDTO);

        ICollection<PublicacaoDTO> MapperList(ICollection<Publicacao> Publicacaos);

        PublicacaoDTO MapperToDTO(Publicacao Publicacao);

        #endregion
    }
}
