using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperAutorizacao
    {
        #region Mappers

        LoginResponseDTO MapperToDTO(PessoaFisica pessoaFisica);

        #endregion
    }
}
