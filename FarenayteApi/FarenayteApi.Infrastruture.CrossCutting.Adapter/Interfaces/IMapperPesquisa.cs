using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperPesquisa
    {
        #region Interfaces Mappers
        
        PessoaJuridica MapperToEntity(PesquisaDTO pessoaJuridicaDTO);

        ICollection<PesquisaDTO> MapperList(ICollection<PessoaJuridica> pessoaJuridicas);

        PesquisaDTO MapperToDTO(PessoaJuridica pessoaJuridica);

        #endregion
    }
}
