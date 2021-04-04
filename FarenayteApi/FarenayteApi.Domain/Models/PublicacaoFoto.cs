using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Domain.Models
{
    [Table("publicacao_foto")]
    public class PublicacaoFoto : Base
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("es_publicacao")]
        public int EsPublicacao { get; set; }

        [Column("foto")]
        public string Foto { get; set; }

        [ForeignKey("EsPublicacao")]
        public virtual Publicacao Publicacao { get; set; }
    }
}