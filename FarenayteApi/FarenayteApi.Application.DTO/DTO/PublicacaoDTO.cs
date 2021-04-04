using Newtonsoft.Json;
using System.Collections.Generic;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PublicacaoDTO
    {
        public int Id { get; set; }

        [JsonIgnore]        
        public int EsPessoaJuridica { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal? Preco { get; set; }
                
        [JsonIgnore]
        public int TipoCobranca { get; set; }
                
        [JsonProperty(PropertyName = "fotos")]
        public virtual ICollection<PublicacaoFotoDTO> PublicacaoFotos { get; set; }

        [JsonProperty(PropertyName = "comentarios")]
        public virtual ICollection<ComentarioDTO> Comentarios { get; set; }
    }
}