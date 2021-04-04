using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServicePessoaFisica
    {
        void Add(PessoaFisicaDTO dto);

        PessoaFisicaDTO GetById(int id);

        ICollection<PessoaFisicaDTO> GetAll();

        void Update(PessoaFisicaDTO dto);

        void Remove(PessoaFisicaDTO dto);

        void Dispose();
    }
}