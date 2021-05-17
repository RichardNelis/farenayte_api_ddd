using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServicePesquisa : IDisposable, IApplicationServicePesquisa
    {
        private readonly IServicePesquisa _service;
        private readonly IMapperPesquisa _mapper;

        public ApplicationServicePesquisa(IServicePesquisa Service, IMapperPesquisa Mapper)
        {
            _service = Service;
            _mapper = Mapper;
        }

        public async Task<ICollection<PesquisaResponseDTO>> GetFilterAsync(PesquisaRequestDTO dto)
        {
            var obj = await _service.GetFilterAsync(dto);
            return _mapper.MapperList(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
