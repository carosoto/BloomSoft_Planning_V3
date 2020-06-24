using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloomSoft_V2.Models;

//Controlador para modelo de tareas

namespace BloomSoft_V2.Controllers
{
    public class TareasController : Controller
    {
        private BSModel db = new BSModel();

        //visualizar los atributos de la tabla Tareas
        // GET: Tareas
        public ActionResult Index()
        {
            var tarea = db.Tarea.Include(t => t.TarjetaRequerim);
            return View(tarea.ToList());
        }

        //visualizar detalles de los atributos de la tabla Tareas
        // GET: Tareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        //Ingresar los atributos de la tabla Tareas
        // GET: Tareas/Create
        public ActionResult Create()
        {
            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim");
            return View();
        }

        // POST: Tareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarjetaRequerim,descripcion")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Tarea.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim", tarea.id_tarjetaRequerim);
            return View(tarea);
        }

        //editar los atributos de la tabla Tareas
        // GET: Tareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim", tarea.id_tarjetaRequerim);
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarjetaRequerim,descripcion")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim", tarea.id_tarjetaRequerim);
            return View(tarea);
        }

        //eliminar los atributos de la tabla Tareas
        // GET: Tareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        //Confirma la eliminacion de los atributos de la tabla Tareas
        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea tarea = db.Tarea.Find(id);
            db.Tarea.Remove(tarea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Acceso a la base de datos
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
