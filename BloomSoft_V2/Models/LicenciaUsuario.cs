namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LicenciaUsuario")]
    public partial class LicenciaUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LicenciaUsuario()
        {
            Pago = new HashSet<Pago>();
        }

        [Key]
        public int id_licencia { get; set; }

        [Required]
        [StringLength(128)]
        public string id_usuario { get; set; }

        public bool estado { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Licencia Licencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }
    }
}
