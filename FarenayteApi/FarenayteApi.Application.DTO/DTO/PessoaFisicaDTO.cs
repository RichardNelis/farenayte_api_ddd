using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PessoaFisicaDTO
    {
        [JsonIgnore]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "es_usuario")]
        public int EsUsuario { get; set; }

        public string Foto { get; set; }

        [JsonProperty(PropertyName = "nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonProperty(PropertyName = "dt_nascimento")]
        public System.DateTime? DtNascimento { get; set; }

        public string Sexo { get; set; }

        [JsonProperty(PropertyName = "telefone_celular")]
        public string TelefoneCelular { get; set; }

        public IFormFile File { get; set; }
    }
}