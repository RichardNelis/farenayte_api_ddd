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
            await ExisteEmail(dto.Email);

            string hmacSHA256 = GenerateHmac.HmacSHA256(dto.Password);
            dto.Password = hmacSHA256;

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

        public async Task UpdatePasswordAsync(UsuarioAlterarSenhaDTO dto)
        {
            string hmacSHA256Atual = GenerateHmac.HmacSHA256(dto.PasswordAtual);
            var objUsuario = await _service.GetByIdAsync(dto.Id);

            if (hmacSHA256Atual == objUsuario.Password)
            {
                string hmacSHA256Nova = GenerateHmac.HmacSHA256(dto.PasswordNova);
                await _service.UpdateAlterarSenhaAsync(dto.Id, hmacSHA256Nova);
            }
        }

        private async Task ExisteEmail(string email)
        {
            var emails = await _service.GetByEmailAsync(email);

            if (emails.Count > 0)
            {
                throw new Exception("O e-mail já esta sendo utilizado.\nInforme um novo e-mail ou tente recuperar a senha.");
            }
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
