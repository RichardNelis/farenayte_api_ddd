using FarenayteApi.Application.DTO.DTO;
using System.Collections.Generic;

namespace FarenayteApi.Application.Interfaces
{
    public interface IApplicationServicePesquisa
    {
        ICollection<PesquisaResponseDTO> GetFilter(PesquisaRequestDTO data);

        void Dispose();
    }
}