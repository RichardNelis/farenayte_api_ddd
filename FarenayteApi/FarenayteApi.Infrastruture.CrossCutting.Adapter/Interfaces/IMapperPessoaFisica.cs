using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperPessoaFisica
    {
        #region Interfaces Mappers
        
        PessoaFisica MapperToEntity(PessoaFisicaDTO pessoaFisicaDTO);

        ICollection<PessoaFisicaDTO> MapperList(ICollection<PessoaFisica> pessoaFisicas);

        PessoaFisicaDTO MapperToDTO(PessoaFisica pessoaFisica);

        PessoaFisicaResponseDTO MapperToDTOResponse(PessoaFisica pessoaFisica);

        #endregion
    }
}
