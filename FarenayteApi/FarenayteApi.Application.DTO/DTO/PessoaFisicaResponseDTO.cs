using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PessoaFisicaResponseDTO
    {
        public string Foto { get; set; }

        [JsonProperty(PropertyName = "nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonProperty(PropertyName = "dt_nascimento")]
        public System.DateTime? DtNascimento { get; set; }

        public string Sexo { get; set; }

        [JsonProperty(PropertyName = "telefone_celular")]
        public string TelefoneCelular { get; set; }        
    }
}