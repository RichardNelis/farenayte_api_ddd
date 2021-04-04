using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PesquisaDTO
    {
        public string Logo { get; set; }

        [JsonProperty(PropertyName = "razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "nome_fantasia")]
        public string NomeFantasia { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal? Preco { get; set; }

        public int IBGE { get; set; }
    }
}