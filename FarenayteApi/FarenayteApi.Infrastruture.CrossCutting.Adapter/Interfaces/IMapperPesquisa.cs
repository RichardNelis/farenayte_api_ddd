using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperPesquisa
    {
        #region Interfaces Mappers

        PessoaJuridica MapperToEntity(PesquisaRequestDTO pessoaJuridicaDTO);

        ICollection<PesquisaResponseDTO> MapperList(ICollection<PessoaJuridica> pessoaJuridicas);

        PesquisaResponseDTO MapperToDTO(PessoaJuridica pessoaJuridica);

        #endregion
    }
}
