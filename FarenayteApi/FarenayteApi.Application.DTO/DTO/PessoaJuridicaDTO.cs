using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PessoaJuridicaDTO
    {
        [JsonProperty(PropertyName = "es_pessoa_fisica")]
        public int EsPessoaFisica { get; set; }

        public string Logo { get; set; }

        public string Cnpj { get; set; }

        [JsonProperty(PropertyName = "razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "nome_fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty(PropertyName = "telefone_celular")]
        public string TelefoneCelular { get; set; }

        public bool Whatsapp { get; set; }

        [JsonProperty(PropertyName = "email_contato")]
        public string EmailContato { get; set; }

        public string Site { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }

        public int UF { get; set; }

        public int IBGE { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "publicacao")]
        public virtual PublicacaoDTO Publicacao { get; set; }
    }
}