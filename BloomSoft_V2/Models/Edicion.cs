
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace BloomSoft_V2.Models
{
    public class Edicion
    {
        public IEnumerable<TarjetaRequerim> tarjetaModels { get; set; }
        public IEnumerable<Tarea> tareaModels { get; set; }
        public IEnumerable<Verbotax> verboModels { get; set; }
        public IEnumerable<VerbosTarjeta> verbotarjetaModels { get; set; }


        public TarjetaRequerim tarjetaModels1 { get; set; }
        public Tarea tareaModels1 { get; set; }
        public Verbotax verboModels1 { get; set; }
        public VerbosTarjeta verbotarjetaModels1 { get; set; }

        public Edicion() 
        {
            tarjetaModels1 = new TarjetaRequerim();
            tareaModels1 = new Tarea();
            verboModels1 = new Verbotax();
            verbotarjetaModels1 = new VerbosTarjeta();
        }

        

    }
}

