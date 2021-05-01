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

        public LoginResponseDTO ValidarAcesso(LoginDTO dto)
        {
            var objUsuarios = GetByEmail(dto.Email);
            var objUsuario = GetByPassword(objUsuarios, dto.Password);
            var objPessoaFisica = _servicePessoaFisica.GetById(objUsuario.Id);

            return _mapper.MapperToDTO(objPessoaFisica);
        }

        public LoginResponseDTO GetById(int id)
        {
            var objUsuario = _serviceUsuario.GetById(id);
            var objPessoaFisica = _servicePessoaFisica.GetById(objUsuario.Id);
            return _mapper.MapperToDTO(objPessoaFisica);
        }

        private ICollection<Domain.Models.Usuario> GetByEmail(string email)
        {
            var objUsuarios = _serviceUsuario.GetByEmail(email);

            if (objUsuarios.Count == 0)
            {
                throw new Exception("Cadastro não encontrado!");
            }

            return objUsuarios;
        }

        private Domain.Models.Usuario GetByPassword(ICollection<Domain.Models.Usuario> objUsuarios, string password)
        {
            var objUsuario = objUsuarios.FirstOrDefault(x => x.Password == password);

            if (objUsuario == null)
            {
                throw new Exception("Senha incorreta!");
            }

            return objUsuario;
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }
    }
}
