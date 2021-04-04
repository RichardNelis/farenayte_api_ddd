using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Application.DTO.DTO
{
    [Table("comentario")]
    public class ComentarioDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "es_publicacao")]
        public int EsPublicacao { get; set; }

        [JsonProperty(PropertyName = "es_pessoa_fisica")]
        public int EsPessoaFisica { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }

        [JsonProperty(PropertyName = "comentario")]
        public string ComentarioPF { get; set; }

        [JsonProperty(PropertyName = "resposta")]
        public string Resposta { get; set; }

        //[JsonIgnore]
        //public virtual PublicacaoDTO Publicacao { get; set; }

        [JsonProperty(PropertyName = "pessoa_fisica")]
        public virtual PessoaFisicaDTO PessoaFisica { get; set; }       
    }
}
