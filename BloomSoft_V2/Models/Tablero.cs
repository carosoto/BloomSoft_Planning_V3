using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.UI.HtmlControls;

namespace BloomSoft_V2.Models
{
    public class Tablero
    {
        public IEnumerable<PartidaJugador> JugadorModel { get; set; }
        public IEnumerable<TarjetaRequerim> tarjetaModels { get; set; }
        public IEnumerable<Tarea> tareaModels { get; set; }
        public IEnumerable<Verbotax> verboModels { get; set; }
        public IEnumerable<VerbosTarjeta> verbotarjetaModels { get; set; }
        public IEnumerable<Requerimiento> requerimientoModels { get; set; }
        public List<TarjetaRequerim> tarjetaList { get; set; }
        public bool check { get; set; }

        public PartidaJugador JugadorM { get; set; }
        public TarjetaRequerim tarjetaM { get; set; }
        public Tarea tareaM { get; set; }
        public Verbotax verboM { get; set; }
        public VerbosTarjeta verbotarjetaM { get; set; }
        public Requerimiento requerimientoM { get; set; }

        public Tablero()
        {

            tarjetaM = new TarjetaRequerim();
            tareaM = new Tarea();
            verboM= new Verbotax();
            verbotarjetaM = new VerbosTarjeta();
            requerimientoM= new Requerimiento();
            JugadorM = new PartidaJugador();
            check = false;
        }
    }
}