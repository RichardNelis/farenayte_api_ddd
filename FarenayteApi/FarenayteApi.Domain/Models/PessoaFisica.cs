using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Domain.Models
{
    [Table("pessoa_fisica")]
    public class PessoaFisica : Base
    {
        [Key]
        [Column("es_usuario")]
        public int EsUsuario { get; set; }

        [Column("foto")]
        public string Foto { get; set; }

        [Column("nome_completo")]
        public string NomeCompleto { get; set; }

        [Column("dt_nascimento")]
        public DateTime? DtNascimento { get; set; }

        [Column("sexo")]
        public string Sexo { get; set; }

        [Column("telefone_celular")]
        public string TelefoneCelular { get; set; }

        public virtual PessoaJuridica PessoaJuridica { get; set; }

        public virtual Comentario Comentario { get; set; }

        [ForeignKey("EsUsuario")]
        public virtual Usuario Usuario { get; set; }
    }
}