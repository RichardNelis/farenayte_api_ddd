using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServiceAutorizacao : IDisposable, IApplicationServiceAutorizacao
    {
        private readonly IServicePessoaFisica _servicePessoaFisica;
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapperAutorizacao _mapper;

        public ApplicationServiceAutorizacao(IServicePessoaFisica ServicePessoaFisica, IServiceUsuario ServiceUsuario, IMapperAutorizacao Mapper)
        {
            _servicePessoaFisica = ServicePessoaFisica;
            _serviceUsuario = ServiceUsuario;
            _mapper = Mapper;
        }

        public async Task<LoginResponseDTO> ValidarAcessoAsync(LoginDTO dto)
        {
            var objUsuarios = await GetByEmailAsync(dto.Email);
            
            string hmacSHA256 = GenerateHmac.HmacSHA256(dto.Password);

            var objUsuario = GetByPassword(objUsuarios, hmacSHA256);
            var objPessoaFisica = await _servicePessoaFisica.GetByIdAsync(objUsuario.Id);
            

            return _mapper.MapperToDTO(objPessoaFisica);
        }

        public async Task<LoginResponseDTO> GetByIdAsync(int id)
        {
            var objUsuario = await _serviceUsuario.GetByIdAsync(id);
            var objPessoaFisica = await _servicePessoaFisica.GetByIdAsync(objUsuario.Id);
            return _mapper.MapperToDTO(objPessoaFisica);
        }

        private async Task<ICollection<Domain.Models.Usuario>> GetByEmailAsync(string email)
        {
            var objUsuarios = await _serviceUsuario.GetByEmailAsync(email);

            if (objUsuarios.Count == 0)
            {
                throw new ArgumentException("Cadastro não encontrado!");
            }

            return objUsuarios;
        }

        private Domain.Models.Usuario GetByPassword(ICollection<Domain.Models.Usuario> objUsuarios, string password)
        {
            var objUsuario = objUsuarios.FirstOrDefault(x => x.Password == password);

            if (objUsuario == null)
            {
                throw new ArgumentException("Senha incorreta!");
            }

            return objUsuario;
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }
    }
}
