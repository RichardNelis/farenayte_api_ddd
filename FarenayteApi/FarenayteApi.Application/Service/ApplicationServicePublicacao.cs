using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServicePublicacao : IDisposable, IApplicationServicePublicacao
    {
        private readonly IServicePublicacao _service;
        private readonly IMapperPublicacao _mapper;

        public ApplicationServicePublicacao(IServicePublicacao Service, IMapperPublicacao Mapper)
        {
            _service = Service;
            _mapper = Mapper;
        }

        public void Add(PublicacaoDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);
        }        

        public PublicacaoDTO GetById(int id)
        {
            var obj = _service.GetById(id);
            return _mapper.MapperToDTO(obj);
        }

        public void Remove(PublicacaoDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Remove(obj);
        }

        public void Update(PublicacaoDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Update(obj);
        }
        
        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
