namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //inicializa los valores para la tabla EstadisticasPartida que guarda
    //los puntajes de los jugadores

    [Table("EstadisticasPartida")]
    public partial class EstadisticasPartida
    {
        [Key]
        public int id_estadistica { get; set; }

        public int id_partidajuego { get; set; }

        public int id_mejorjugador { get; set; }

        public int id_peorjugador { get; set; }

        public int mejor_puntaje { get; set; }

        public int peor_puntaje { get; set; }

        public virtual PartidaJuego PartidaJuego { get; set; }

        public virtual PartidaJugador PartidaJugador { get; set; }

        public virtual PartidaJugador PartidaJugador1 { get; set; }
    }
}
