using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Domain.Models
{
    [Table("comentario")]
    public class Comentario : Base
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("es_publicacao")]
        public int EsPublicacao { get; set; }

        [Column("es_pessoa_fisica")]
        public int EsPessoaFisica { get; set; }

        [Column("rating")]
        public double Rating { get; set; }

        [Column("comentario")]
        public string ComentarioPF { get; set; }

        [Column("resposta")]
        public string Resposta { get; set; }

        [ForeignKey("EsPublicacao")]
        public virtual Publicacao Publicacao { get; set; }

        [ForeignKey("EsPessoaFisica")]
        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}
