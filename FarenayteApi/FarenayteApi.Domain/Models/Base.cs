using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarenayteApi.Domain.Models
{
    public class Base
    {
        [Column("dt_inclusao")]
        public DateTime DataInclusao { get; set; }

        [Column("dt_alteracao")]
        public DateTime? DataAlteracao { get; set; }
    }
}
