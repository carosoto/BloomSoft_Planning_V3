namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //registra el verbo y el nivel de la taxonomia que le corresponde

    [Table("Verbotax")]
    public partial class Verbotax
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Verbotax()
        {
            VerbosTarjeta = new HashSet<VerbosTarjeta>();
        }

        [Key]
        public int id_verbo { get; set; }

        public int nivel_tax { get; set; }

        [Required]
        [StringLength(200)]
        public string verbos { get; set; }

        public virtual Taxonomia Taxonomia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerbosTarjeta> VerbosTarjeta { get; set; }
    }
}
