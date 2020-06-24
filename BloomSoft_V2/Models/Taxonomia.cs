namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //registra los niveles de la taxonomia usados en el registro de la tarjeta de juego

    [Table("Taxonomia")]
    public partial class Taxonomia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taxonomia()
        {
            TarjetaRequerim = new HashSet<TarjetaRequerim>();
            Verbotax = new HashSet<Verbotax>();
        }

        [Key]
        public int nivel_tax { get; set; }

        [Required]
        [StringLength(100)]
        public string categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaRequerim> TarjetaRequerim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verbotax> Verbotax { get; set; }
    }
}
