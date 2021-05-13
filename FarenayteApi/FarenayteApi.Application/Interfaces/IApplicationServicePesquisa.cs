using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServicePesquisa
    {
        Task<ICollection<PesquisaResponseDTO>> GetFilterAsync(PesquisaRequestDTO data);

        void Dispose();
    }
}