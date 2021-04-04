using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServicePessoaFisica : IDisposable, IApplicationServicePessoaFisica
    {
        private readonly IServicePessoaFisica _service;
        private readonly IMapperPessoaFisica _mapper;

        public ApplicationServicePessoaFisica(IServicePessoaFisica Service, IMapperPessoaFisica Mapper)
        {
            _service = Service;
            _mapper = Mapper;
        }

        public void Add(PessoaFisicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public ICollection<PessoaFisicaDTO> GetAll()
        {
            var obj = _service.GetAll();
            return _mapper.MapperList(obj);
        }

        public PessoaFisicaDTO GetById(int id)
        {
            var obj = _service.GetById(id);
            return _mapper.MapperToDTO(obj);
        }

        public void Remove(PessoaFisicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Remove(obj);
        }

        public void Update(PessoaFisicaDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Update(obj);
        }
    }
}
