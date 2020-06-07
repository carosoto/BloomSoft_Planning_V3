namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using BloomSoft_V2.Models;

    [Table("PartidaJugador")]
    public partial class PartidaJugador
    {
        private BSModel db = new BSModel();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartidaJugador()
        {
            EstadisticasPartida = new HashSet<EstadisticasPartida>();
            EstadisticasPartida1 = new HashSet<EstadisticasPartida>();
            TarjetaRequerim = new HashSet<TarjetaRequerim>();
        }

        [Key]
        public int id_partidaJugador { get; set; }

        public int id_partidaJuego { get; set; }

        [Required]
        [StringLength(128)]
        public string id_usuario { get; set; }

        public int? puntos { get; set; }

        public bool turno { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadisticasPartida> EstadisticasPartida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadisticasPartida> EstadisticasPartida1 { get; set; }

        public virtual PartidaJuego PartidaJuego { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaRequerim> TarjetaRequerim { get; set; }

        public void quitaTurno(){ turno = false; }
        public void asignaTurno() { turno = true; }

    }
}
