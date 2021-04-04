using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperPublicacaoFoto
    {
        #region Interfaces Mappers
        
        PublicacaoFoto MapperToEntity(PublicacaoFotoDTO PublicacaoFotoDTO);

        ICollection<PublicacaoFotoDTO> MapperList(ICollection<PublicacaoFoto> PublicacaoFotos);

        PublicacaoFotoDTO MapperToDTO(PublicacaoFoto Publicacao);

        #endregion
    }
}
