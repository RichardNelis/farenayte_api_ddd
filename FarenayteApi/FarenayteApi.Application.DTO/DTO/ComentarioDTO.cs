using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Application.DTO.DTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "es_publicacao")]
        public int EsPublicacao { get; set; }

        [JsonProperty(PropertyName = "es_pessoa_fisica")]
        public int EsPessoaFisica { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "comentario")]
        public string ComentarioPF { get; set; }

        [JsonProperty(PropertyName = "resposta")]
        public string Resposta { get; set; }

        [JsonProperty(PropertyName = "pessoa_fisica")]
        public virtual PessoaFisicaDTO PessoaFisica { get; set; }
    }
}
