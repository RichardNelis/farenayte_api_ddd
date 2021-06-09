using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task AddAsync(ComentarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            await _service.AddAsync(obj);
            dto.Id = obj.Id;
        }

        public async Task<ComentarioDTO> GetByIdAsync(int id)
        {
            var obj = await _service.GetByIdAsync(id);
            return _mapper.MapperToDTO(obj);
        }

        public async Task<ComentarioDTO> GetByIdWithPessoaFisicaAsync(int id)
        {
            var obj = await _service.GetByIdWithPessoaFisicaAsync(id);
            return _mapper.MapperToDTO(obj);
        }

        public async Task<ICollection<ComentarioDTO>> GetByEsPublicacaoAsync(int id)
        {
            var obj = await _service.GetByEsPublicacaoAsync(id);
            return _mapper.MapperList(obj);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(obj);
        }

        public async Task UpdateAsync(ComentarioDTO dto)
        {
            var obj = _mapper.MapperToEntity(dto);
            await _service.UpdateAsync(obj);
        }

        public async Task RemoverRespostaAsync(int id)
        {
            var obj = await _service.GetByIdAsync(id);
            obj.Resposta = null;
            await _service.UpdateAsync(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
