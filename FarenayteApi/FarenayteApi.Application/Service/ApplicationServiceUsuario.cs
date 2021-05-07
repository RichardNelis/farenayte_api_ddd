using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServiceUsuario : IDisposable, IApplicationServiceUsuario
    {
        private readonly IMapperUsuario _mapper;
        private readonly IServiceUsuario _service;
        private readonly IServicePessoaFisica _servicePessoaFisica;

        public ApplicationServiceUsuario(IServicePessoaFisica ServicePessoaFisica, IServiceUsuario Service, IMapperUsuario Mapper)
        {
            _mapper = Mapper;
            _service = Service;
            _servicePessoaFisica = ServicePessoaFisica;
        }

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
