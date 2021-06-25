using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class UsuarioDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "pessoa_fisica")]
        public virtual PessoaFisicaDTO PessoaFisica { get; set; }
    }
}