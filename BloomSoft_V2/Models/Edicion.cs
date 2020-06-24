
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

//Modelo multiple que une los modelos Tarjetarequerim, Tarea, Verbotax
//VerbosTarjeta, Requerimiento y partidaJugador para la cracion de las tarjetas del juego

namespace BloomSoft_V2.Models
{
    public class Edicion
    {
        public IEnumerable<TarjetaRequerim> tarjetaModels { get; set; }
        public IEnumerable<Tarea> tareaModels { get; set; }
        public IEnumerable<Verbotax> verboModels { get; set; }
        public IEnumerable<VerbosTarjeta> verbotarjetaModels { get; set; }      
        public IEnumerable<Requerimiento> requerimientoModels { get; set; }
        public IEnumerable<PartidaJugador> partidaModels { get; set; }


        public TarjetaRequerim tarjetaModels1 { get; set; }
        public Tarea tareaModels1 { get; set; }
        public Verbotax verboModels1 { get; set; }
        public VerbosTarjeta verbotarjetaModels1 { get; set; }  
        public Requerimiento requerimientoModels1 { get; set; }
        public PartidaJugador partidaModels1 { get; set; }

        public Edicion() 
        {
            tarjetaModels1 = new TarjetaRequerim();
            tareaModels1 = new Tarea();
            verboModels1 = new Verbotax();
            verbotarjetaModels1 = new VerbosTarjeta();         
            requerimientoModels1 = new Requerimiento();
            partidaModels1 = new PartidaJugador();
        }

        

    }
}

