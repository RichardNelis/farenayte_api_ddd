using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Threading.Tasks;

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

        public async Task<UsuarioResponseDTO> AddAsync(UsuarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            await _service.AddAsync(obj);

            return _mapper.MapperToDTOResponse(obj);
        }

        public async Task UpdateAsync(UsuarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            await _service.UpdateAsync(obj);
        }

        public async Task<UsuarioDTO> GetByIdAsync(int id)
        {
            var objUsuario = await _service.GetByIdAsync(id);
            return _mapper.MapperToDTO(objUsuario);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
