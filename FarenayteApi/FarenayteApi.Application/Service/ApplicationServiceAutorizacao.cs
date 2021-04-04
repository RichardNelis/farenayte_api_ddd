using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
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

        public async Task<LoginDTO> ValidarAcesso(UsuarioDTO usuarioDTO)
        {
            var objUsuarios = await _serviceUsuario.GetByEmail(usuarioDTO.Email);

            if (objUsuarios.Count == 0)
            {
                throw new Exception("Cadastro não encontrado!");
            }

            var objUsuario = objUsuarios.FirstOrDefault(x => x.Password == usuarioDTO.Password);

            if (objUsuario == null)
            {
                throw new Exception("Senha incorreta!");
            }

            var objPessoaFisica = _servicePessoaFisica.GetById(objUsuario.Id);
            return _mapper.MapperToDTO(objPessoaFisica);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }
    }
}
