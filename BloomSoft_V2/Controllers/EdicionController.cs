using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BloomSoft_V2.Models;
using Microsoft.AspNet.Identity;

//Controlador para creación y modificación de tarjetas de requerimientos

namespace BloomSoft_V2.Controllers
{
    public class EdicionController : Controller
    {
        BSModel db = new BSModel();
        

        //muestra las tarjetas de cada jugador para que se modifiquen
        public ActionResult Index()
        {

            var edicion = new Edicion
            {
                tarjetaModels = db.TarjetaRequerim,
                tareaModels = db.Tarea,
                verboModels = db.Verbotax,
                verbotarjetaModels=db.VerbosTarjeta,
                requerimientoModels = db.Requerimiento,
                partidaModels=db.PartidaJugador
            };

            return View(edicion);

        }

        //muestra el contenido de las tarjetas creadas
        public ActionResult Muestra()
        {
            var edicion = new Edicion
            {
                tarjetaModels = db.TarjetaRequerim,
                tareaModels = db.Tarea,
                verboModels = db.Verbotax,
                verbotarjetaModels = db.VerbosTarjeta,
                requerimientoModels=db.Requerimiento,
                partidaModels = db.PartidaJugador
            };

            return View(edicion);
        }
        
        //Agrega a la tarjeta de requerimientos verbos tareas duracion y dificultad del requerimiento
        // GET: Edicion/Create
        public ActionResult Create(int id_t, int id_r)
        {
            Edicion edicion = new Edicion();
            
            edicion.tarjetaModels1.id_requerimiento = id_r;

            edicion.requerimientoModels = db.Requerimiento.ToList();
            edicion.partidaModels = db.PartidaJugador.ToList();
            var lista = edicion.partidaModels.ToList().Find(p => p.id_usuario == User.Identity.GetUserId());
            var busqueda = lista.id_partidaJugador;
            edicion.tarjetaModels1.id_partidaJugador = busqueda;
            edicion.tarjetaModels1.puntos = 100;
            edicion.tareaModels1.id_tarjetaRequerim = id_t;
            edicion.verbotarjetaModels1.id_tarjetaRequerim = id_t;          
            ViewBag.id_verbo = new SelectList(db.Verbotax, "id_verbo", "verbos");

            return View(edicion);

        }

        //POST
        [HttpPost]
        public ActionResult Create(Edicion model)
        {
            
            if (ModelState.IsValid)
            {
                
                db.TarjetaRequerim.Add(model.tarjetaModels1);
                db.Tarea.Add(model.tareaModels1);
                db.VerbosTarjeta.Add(model.verbotarjetaModels1);

                db.SaveChanges();

                return RedirectToAction("Muestra");
            }
            
            return View(model);
        }

       
        //modifica la informacion de tiempo y dificultad en las tarjetas en el tablero
            public ActionResult Edit(int? id, int nivel)
            {
            
              if (id == null)
              {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
            Edicion edicion = new Edicion();
            edicion.tarjetaModels1 = db.TarjetaRequerim.Find(id);
            edicion.tarjetaModels1.nivel_tax = nivel;
                      
              if (edicion == null)
              {
                return HttpNotFound();
              }
               return View(edicion);
            }  

        //POST
        [HttpPost]
        public ActionResult Edit(Edicion edicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edicion.tarjetaModels1).State = EntityState.Modified;      
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edicion);
        }

        //modifica la informacion de tareas en las tarjetas en el tablero
        public ActionResult Edit2(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edicion edicion = new Edicion();
            edicion.tareaModels1= db.Tarea.Find(id);

            if (edicion == null)
            {
                return HttpNotFound();
            }
            return View(edicion);
        }

        //POST
        [HttpPost]
        public ActionResult Edit2(Edicion edicion)
        {
            if (ModelState.IsValid)
            {                
                db.Entry(edicion.tareaModels1).State = EntityState.Modified;               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edicion);
        }

        //modifica la informacion de los verbos en las tarjetas en el tablero
        public ActionResult Edit3(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edicion edicion = new Edicion();
            edicion.verbotarjetaModels1 = db.VerbosTarjeta.Find(id);
            if (edicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_verbo = new SelectList(db.Verbotax, "id_verbo", "verbos", edicion.verbotarjetaModels1.id_verbo);
            
            return View(edicion);
        }

        //POST
        [HttpPost]
        public ActionResult Edit3(Edicion edicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edicion.verbotarjetaModels1).State = EntityState.Modified;
                db.SaveChanges();               
                return RedirectToAction("Index");
            }
           
            return View(edicion);
        }
    }
}
