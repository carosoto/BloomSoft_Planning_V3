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
        
        public int id_tarjetaRequerim { get; set; }

        public string descripcion { get; set; }

        [Key]
        public int id_tarea { get; set; }

        public virtual TarjetaRequerim TarjetaRequerim { get; set; }
    }
}
