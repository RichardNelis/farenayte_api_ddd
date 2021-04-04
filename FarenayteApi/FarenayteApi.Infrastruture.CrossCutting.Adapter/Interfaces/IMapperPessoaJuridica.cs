using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Domain.Models;
using System.Collections.Generic;

namespace FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperPessoaJuridica
    {
        #region Interfaces Mappers
        
        PessoaJuridica MapperToEntity(PessoaJuridicaDTO pessoaJuridicaDTO);

        ICollection<PessoaJuridicaDTO> MapperList(ICollection<PessoaJuridica> pessoaJuridicas);

        PessoaJuridicaDTO MapperToDTO(PessoaJuridica pessoaJuridica);

        #endregion
    }
}
