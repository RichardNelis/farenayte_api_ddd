using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PublicacaoFotoDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "es_publicacao")]
        public int EsPublicacao { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public string Foto { get; set; }
    }
}