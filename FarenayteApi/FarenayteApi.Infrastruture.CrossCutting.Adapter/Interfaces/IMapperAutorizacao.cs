using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperAutorizacao
    {
        #region Mappers

        LoginResponseDTO MapperToDTO(PessoaFisica pessoaFisica);

        #endregion
    }
}
