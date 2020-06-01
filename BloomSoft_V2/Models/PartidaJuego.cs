namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartidaJuego")]
    public partial class PartidaJuego
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartidaJuego()
        {
            PartidaJugador = new HashSet<PartidaJugador>();
        }

        [Key]
        public int id_partidaJuego { get; set; }

        public int id_proyecto { get; set; }

        [Required]
        [StringLength(128)]
        public string id_usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public TimeSpan hora { get; set; }

        public bool estado { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartidaJugador> PartidaJugador { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
