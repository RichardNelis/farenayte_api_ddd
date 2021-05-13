using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServicePessoaJuridica : IDisposable, IApplicationServicePessoaJuridica
    {
        private readonly IServicePessoaJuridica _service;
        private readonly IMapperPessoaJuridica _mapper;

        public ApplicationServicePessoaJuridica(IServicePessoaJuridica Service, IMapperPessoaJuridica Mapper)
        {
            _service = Service;
            _mapper = Mapper;
        }

        public async Task AddAsync(PessoaJuridicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            await _service.AddAsync(obj);
        }

        public async Task<PessoaJuridicaDTO> GetByIdAsync(int id)
        {
            var obj = await _service.GetByIdAsync(id);
            return _mapper.MapperToDTO(obj);
        }

        public async Task<PessoaJuridicaDTO> GetByIdFullAsync(int id)
        {
            var obj = await _service.GetByIdFullAsync(id);
            return _mapper.MapperToDTO(obj);
        }

        public async Task UpdateAsync(PessoaJuridicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            await _service.UpdateAsync(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
