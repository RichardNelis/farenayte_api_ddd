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
        private readonly IServicePessoaFisica _servicePessoaFisica;
        private readonly IServiceUsuario _service;
        private readonly IMapperUsuario _mapper;

        public ApplicationServiceUsuario(IServicePessoaFisica ServicePessoaFisica, IServiceUsuario Service, IMapperUsuario Mapper)
        {
            _servicePessoaFisica = ServicePessoaFisica;
            _service = Service;
            _mapper = Mapper;
        }

        /*public async Task<ICollection<UsuarioDTO>> GetByEmail(string email)
        {
            var objUsuario = await _service.GetByEmail(email);
            return _mapper.MapperListUsuarios(objUsuario);
        }*/
        /*public async Task<ICollection<UsuarioDTO>> GetAllAsync()
        {
            var objUsuario = await _service.GetAllAsync();
            return _mapper.MapperListUsuarios(objUsuario);
        }*/

        public UsuarioResponseDTO Add(UsuarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            _service.Add(obj);

            return _mapper.MapperToDTOResponse(obj);
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

        public UsuarioDTO GetById(int id)
        {
            var objUsuario = _service.GetById(id);            
            return _mapper.MapperToDTO(objUsuario);
        }
    }
}
