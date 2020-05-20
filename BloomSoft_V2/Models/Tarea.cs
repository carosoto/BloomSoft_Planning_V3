namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tarea")]
    public partial class Tarea
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tarjetaRequerim { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string descripcion { get; set; }

        public virtual TarjetaRequerim TarjetaRequerim { get; set; }
    }
}
