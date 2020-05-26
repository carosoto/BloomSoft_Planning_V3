using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BloomSoft_V2.Models
{
    [Table("VerbosTarjeta")]
    public class VerbosTarjeta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tarjetaRequerim { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_verbo { get; set; }

        public virtual TarjetaRequerim TarjetaRequerim { get; set; }
        public virtual Verbotax Verbotax { get; set; }

    }
}