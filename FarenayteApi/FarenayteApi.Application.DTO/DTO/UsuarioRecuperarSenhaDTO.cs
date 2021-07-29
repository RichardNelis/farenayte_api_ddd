using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class UsuarioRecuperarSenhaDTO
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }      
    }
}