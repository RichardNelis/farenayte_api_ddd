using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;

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

        public ICollection<PesquisaResponseDTO> GetFilter(PesquisaRequestDTO dto)
        {            
            var obj = _service.GetFilter(_mapper.MapperToEntity(dto));
            return _mapper.MapperList(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
