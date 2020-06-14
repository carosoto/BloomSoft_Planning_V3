namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Requerimiento")]
    public partial class Requerimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requerimiento()
        {
           
            TarjetaRequerim = new HashSet<TarjetaRequerim>();
        }

        [Key]
        public int id_requerimiento { get; set; }

        public int id_proyecto { get; set; }

        public string descripcion { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaRequerim> TarjetaRequerim { get; set; }
    }
}
