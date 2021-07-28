using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
            var obj = await _serviceUsuario.GetByEmailAsync(dto.Email);

            string hmacSHA256 = GenerateHmac.HmacSHA256(dto.Password);

            var objUsuario = GetByPassword(obj, hmacSHA256);
            var objPessoaFisica = await _servicePessoaFisica.GetByIdAsync(objUsuario.Id);

            return _mapper.MapperToDTO(objPessoaFisica);
        }

        public async Task<LoginResponseDTO> GetByIdAsync(int id)
        {
            var objUsuario = await _serviceUsuario.GetByIdAsync(id);
            var objPessoaFisica = await _servicePessoaFisica.GetByIdAsync(objUsuario.Id);
            return _mapper.MapperToDTO(objPessoaFisica);
        }

        private Domain.Models.Usuario GetByPassword(Domain.Models.Usuario obj, string password)
        {
            if (obj.Password != password)
            {
                throw new ArgumentException("Senha incorreta!");
            }

            return obj;
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }
    }
}
