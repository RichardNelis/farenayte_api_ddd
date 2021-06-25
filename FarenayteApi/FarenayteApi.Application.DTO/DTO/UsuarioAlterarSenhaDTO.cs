using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class UsuarioAlterarSenhaDTO
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "password_atual")]
        public string PasswordAtual { get; set; }

        [JsonProperty(PropertyName = "password_nova")]
        public string PasswordNova { get; set; }
    }
}