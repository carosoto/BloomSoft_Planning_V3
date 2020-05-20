namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verbotax")]
    public partial class Verbotax
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Verbotax()
        {
            TarjetaRequerim = new HashSet<TarjetaRequerim>();
        }

        [Key]
        public int id_verbo { get; set; }

        public int nivel_tax { get; set; }

        public virtual Taxonomia Taxonomia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaRequerim> TarjetaRequerim { get; set; }
    }
}
