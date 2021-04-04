using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServicePessoaJuridica
    {
        void Add(PessoaJuridicaDTO dto);

        PessoaJuridicaDTO GetById(int id);

        ICollection<PessoaJuridicaDTO> GetAll();
                
        void Update(PessoaJuridicaDTO dto);

        void Remove(PessoaJuridicaDTO dto);

        void Dispose();
    }
}