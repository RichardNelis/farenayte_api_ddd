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

        public async Task<ICollection<UsuarioDTO>> GetByEmail(string email)
        {
            var objUsuario = await _service.GetByEmail(email);
            return _mapper.MapperListUsuarios(objUsuario);
        }        

        public async Task<ICollection<UsuarioDTO>> GetAllAsync()
        {
            var objUsuario = await _service.GetAllAsync();
            return _mapper.MapperListUsuarios(objUsuario);
        }        

        public void Add(UsuarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);
        }

        public void Update(UsuarioDTO dto)
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
