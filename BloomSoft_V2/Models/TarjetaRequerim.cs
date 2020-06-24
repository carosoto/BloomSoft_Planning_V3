namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //registra la informacion del tiempo, dificultad y puntos y une los modelos de requerimientos tareas, verbos y 
    //nivel de la taxonomaia para crear la tarjeta de juego

    [Table("TarjetaRequerim")]
    public partial class TarjetaRequerim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TarjetaRequerim()
        {
            VerbosTarjeta = new HashSet<VerbosTarjeta>();
            Tarea = new HashSet<Tarea>();
        }

        [Key]
        public int id_tarjetaRequerim { get; set; }

        public int id_requerimiento { get; set; }

        public int id_partidaJugador { get; set; }

        public int nivel_tax { get; set; }

        public int tiempo { get; set; }

        public int dificultad { get; set; }

        public int puntos { get; set; }

        public virtual PartidaJugador PartidaJugador { get; set; }

        public virtual Requerimiento Requerimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerbosTarjeta> VerbosTarjeta { get; set; }

        public virtual Taxonomia Taxonomia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
