using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServiceUsuario : IDisposable, IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _service;
        private readonly IMapperUsuario _mapper;

        public ApplicationServiceUsuario(IServiceUsuario Service, IMapperUsuario Mapper)
        {
            _service = Service;
            _mapper = Mapper;
        }

        public async Task<ICollection<UsuarioRequestDTO>> GetByEmail(string email)
        {
            var objUsuario = await _service.GetByEmail(email);
            return _mapper.MapperListUsuarios(objUsuario);
        }        

        public async Task<ICollection<UsuarioRequestDTO>> GetAllAsync()
        {
            var objUsuario = await _service.GetAllAsync();
            return _mapper.MapperListUsuarios(objUsuario);
        }        

        public void Add(UsuarioRequestDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);
        }

        public void Update(UsuarioRequestDTO dto)
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
