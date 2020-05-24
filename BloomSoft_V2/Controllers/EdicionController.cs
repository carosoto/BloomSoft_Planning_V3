using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloomSoft_V2.Models;
using Microsoft.AspNet.Identity;

namespace BloomSoft_V2.Controllers
{
    public class EdicionController : Controller
    {
        BSModel db = new BSModel();



        public ActionResult Index()
        {

            var edicion = new Edicion
            {
                tarjetaModels = db.TarjetaRequerim,
                tareaModels = db.Tarea,
                verboModels = db.Verbotax

            };

            return View(edicion);

        }

        public ActionResult Muestra()
        {
            var edicion = new Edicion
            {
                tarjetaModels = db.TarjetaRequerim,
                tareaModels = db.Tarea,
                verboModels = db.Verbotax

            };

            return View(edicion);
        }

        // GET: Edicion/Create
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Edicion model)
        {
            if (ModelState.IsValid)
            {
                db.TarjetaRequerim.Add(model.tarjetaModels1);
                db.Tarea.Add(model.tareaModels1);
                db.Verbotax.Add(model.verboModels1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edicion edicion = new Edicion();
            edicion.tarjetaModels1 = db.TarjetaRequerim.Find(id);           
            if (edicion == null)
            {
                return HttpNotFound();
            }
            return View(edicion);
        }

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

       public ActionResult Edit2(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edicion edicion = new Edicion();          
            edicion.tareaModels1 = db.Tarea.Find(id);         
            if (edicion == null)
            {
                return HttpNotFound();
            }
            return View(edicion);
        }

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

        public ActionResult Edit3(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edicion edicion = new Edicion();
            edicion.verboModels1 = db.Verbotax.Find(id);
            if (edicion == null)
            {
                return HttpNotFound();
            }
            return View(edicion);
        }

        [HttpPost]
        public ActionResult Edit3(Edicion edicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edicion.verboModels1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edicion);
        }
    }
}
