using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;

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

        public void Add(PessoaJuridicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public PessoaJuridicaDTO GetById(int id)
        {
            var obj = _service.GetById(id);
            return _mapper.MapperToDTO(obj);
        }

        public PessoaJuridicaDTO GetByIdFull(int id)
        {
            var obj = _service.GetByIdFull(id);
            return _mapper.MapperToDTO(obj);
        }

        public void Remove(PessoaJuridicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Remove(obj);
        }

        public void Update(PessoaJuridicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Update(obj);
        }
    }
}
