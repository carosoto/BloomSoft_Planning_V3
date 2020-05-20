namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartidaJugador")]
    public partial class PartidaJugador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartidaJugador()
        {
            TarjetaRequerim = new HashSet<TarjetaRequerim>();
        }

        [Key]
        public int id_partidaJugador { get; set; }

        public int id_partidaJuego { get; set; }

        [Required]
        [StringLength(128)]
        public string id_usuario { get; set; }

        public int? puntos { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual PartidaJuego PartidaJuego { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaRequerim> TarjetaRequerim { get; set; }
    }
}
