using FarenayteApi.Application.DTO.DTO;
using FarenayteApi.Application.Interfaces;
using FarenayteApi.Domain.Core.Interfaces.Services;
using FarenayteApi.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FarenayteApi.Application.Service
{
    public class ApplicationServiceUsuario : IDisposable, IApplicationServiceUsuario
    {
        private readonly IMapperUsuario _mapper;
        private readonly IServiceUsuario _service;
        
        public ApplicationServiceUsuario(IServiceUsuario Service, IMapperUsuario Mapper)
        {
            _mapper = Mapper;
            _service = Service;            
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

        public async Task<UsuarioResponseDTO> GetByIdAsync(int id)
        {
            var objUsuario = await _service.GetByIdAsync(id);
            return _mapper.MapperToDTOResponse(objUsuario);
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
            var obj = await _service.GetByEmailAsync(email);

            if (obj != null && obj.Id > 0)
            {
                throw new Exception("O e-mail já esta sendo utilizado.\nInforme um novo e-mail ou tente recuperar a senha.");
            }
        }

        private async Task<Domain.Models.Usuario> GetByEmailAsync(string email)
        {
            var obj = await _service.GetByEmailAsync(email);

            if (obj.Id == 0)
            {
                throw new ArgumentException("Cadastro não encontrado!");
            }

            return obj;
        }

        public async Task RecuperarSenhaAsync(string email)
        {
            try
            {
                var obj = await GetByEmailAsync(email);

                String newPassword = GeradorPassword();
                string hmacSHA256 = GenerateHmac.HmacSHA256(newPassword);

                await _service.UpdateAlterarSenhaAsync(obj.Id, hmacSHA256);

                string title = "Recuperar Senha";

                StringBuilder body = new StringBuilder();
                body.AppendLine("<h2>Geramos uma nova senha para seu acesso.</h2>")
                    .AppendLine("<p>")
                    .AppendLine($"<strong>Email:</strong> {email}<br/>")
                    .AppendLine($"<strong>Nova Senha:</strong> {newPassword}")
                    .AppendLine("</p>");

                EnviarEmail(email, title, body);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String GeradorPassword()
        {
            string validar = "abcdefghijklmnozABCDEFGHIJKLMNOZ1234567890";

            StringBuilder strbld = new StringBuilder();
            int TamanhoDaSenha = 8;

            Random random = new Random();

            while (0 < TamanhoDaSenha--)
            {
                strbld.Append(validar[random.Next(validar.Length)]);
            }

            return strbld.ToString();
        }

        private void EnviarEmail(String email, String title, StringBuilder body)
        {
            try
            {
                var fromAddress = new MailAddress("fare.nayteapp@gmail.com", "Farenayte APP");
                var toAddress = new MailAddress(email);
                const string fromPassword = "E4cr5qx3*";

                var smtp = new SmtpClient
                {
                    Port = 587,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = title,
                    IsBodyHtml = true,
                    Body = body.ToString()
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar enviar o e-mail.\nTente novamente mais tarde!");
            }
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}