namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VerbosTarjeta")]
    public partial class VerbosTarjeta
    {
        [Key]
        public int id_verbostarjeta { get; set; }

        public int id_tarjetaRequerim { get; set; }

        public int id_verbo { get; set; }

        public virtual TarjetaRequerim TarjetaRequerim { get; set; }

        public virtual Verbotax Verbotax { get; set; }
    }
}
