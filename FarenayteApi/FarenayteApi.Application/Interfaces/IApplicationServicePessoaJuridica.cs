using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServicePessoaJuridica
    {
        Task AddAsync(PessoaJuridicaDTO dto);

        Task<PessoaJuridicaDTO> GetByIdAsync(int id);

        Task<PessoaJuridicaDTO> GetByIdFullAsync(int id);
                
        Task UpdateAsync(PessoaJuridicaDTO dto);

        void Dispose();
    }
}