using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Domain.Models
{
    [Table("publicacao")]
    public class Publicacao : Base
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("es_pessoa_juridica")]
        public int EsPessoaJuridica { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("preco")]
        public decimal? Preco { get; set; }

        [Column("tipo_cobranca")]
        public int TipoCobranca { get; set; }

        [ForeignKey("EsPessoaJuridica")]
        public virtual PessoaJuridica PessoaJuridica { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual ICollection<PublicacaoFoto> PublicacaoFotos { get; set; }

        public Publicacao(string titulo, string descricao, decimal? preco)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
        }

        public Publicacao()
        {
        }
    }
}