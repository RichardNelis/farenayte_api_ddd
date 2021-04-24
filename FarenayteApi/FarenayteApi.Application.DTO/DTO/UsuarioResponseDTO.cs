using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class UsuarioResponseDTO
    {

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "pessoa_fisica")]
        public virtual PessoaFisicaResponseDTO PessoaFisica { get; set; }
    }
}