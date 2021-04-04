using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class LoginDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonProperty(PropertyName = "photo")]
        public string Photo { get; set; }

        [JsonProperty(PropertyName = "es_pessoa_juridica")]
        public int EsPessoaJuridica { get; set; }
    }
}