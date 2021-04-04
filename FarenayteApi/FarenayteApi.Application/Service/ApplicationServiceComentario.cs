using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServiceComentario : IDisposable, IApplicationServiceComentario
    {
        private readonly IServiceComentario _service;
        private readonly IMapperComentario _mapper;

        public ApplicationServiceComentario(IServiceComentario Service, IMapperComentario Mapper)
        {
            _service = Service;
            _mapper = Mapper;
        }

        public void Add(ComentarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public ICollection<ComentarioDTO> GetAll()
        {
            var obj = _service.GetAll();
            return _mapper.MapperList(obj);
        }

        public ComentarioDTO GetById(int id)
        {
            var obj = _service.GetById(id);
            return _mapper.MapperToDTO(obj);
        }

        public void Remove(ComentarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Remove(obj);
        }

        public void Update(ComentarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Update(obj);
        }
    }
}
