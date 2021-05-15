using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Domain.Models
{
    [Table("pessoa_juridica")]
    public class PessoaJuridica : Base
    {
        [Key]
        [Column("es_pessoa_fisica")]
        public int EsPessoaFisica { get; set; }

        [Column("logo")]
        public string Logo { get; set; }

        [Column("cnpj")]
        public string Cnpj { get; set; }

        [Column("razao_social")]
        public string RazaoSocial { get; set; }

        [Column("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [Column("telefone_celular")]
        public string TelefoneCelular { get; set; }

        [Column("whatsapp")]
        public bool Whatsapp { get; set; }

        [Column("email_contato")]
        public string EmailContato { get; set; }

        [Column("site")]
        public string Site { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("uf")]
        public string UF { get; set; }

        [Column("ibge")]
        public int IBGE { get; set; }

        [Column("latitude")]
        public double Latitude { get;set; }

        [Column("longitude")]
        public double Longitude { get;set; }

        [ForeignKey("EsPessoaFisica")]
        public virtual PessoaFisica PessoaFisica { get; set; }

        public virtual Publicacao Publicacao { get; set; }
    }
}