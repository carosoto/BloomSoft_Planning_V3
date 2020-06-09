using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BloomSoft_V2.Models
{
    public class Tablero
    {
        public IEnumerable<PartidaJugador> JugadorModel { get; set; }
        //public IEnumerable<Edicion> edicionModel { get; set; }

        public PartidaJugador JugadorM { get; set; }
        public Edicion edicionM { get; set; }

        public Tablero()
        {
            edicionM = new Edicion();
            JugadorM = new PartidaJugador();
        }
    }
}