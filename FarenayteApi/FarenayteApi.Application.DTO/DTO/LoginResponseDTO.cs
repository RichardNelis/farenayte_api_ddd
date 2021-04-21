using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class LoginResponseDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public string Foto { get; set; }

        [JsonProperty(PropertyName = "es_pessoa_juridica")]
        public int EsPessoaJuridica { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}