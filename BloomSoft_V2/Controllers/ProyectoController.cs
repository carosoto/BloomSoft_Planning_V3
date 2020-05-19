using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloomSoft_V2.Models;

namespace BloomSoft_V2.Controllers
{
    public class ProyectoController : Controller
    {
        private BSModel db = new BSModel();

        // GET: Proyecto
        public ActionResult Index()
        {
            var proyecto = db.Proyecto.Include(p => p.AspNetUsers);
            return View(proyecto.ToList());
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proyecto,nombre,id_usuario,estado,interaciones")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Create", "PartidaJuego");
            }

            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.id_usuario);
            return View(proyecto);
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.id_usuario);
            return View(proyecto);
        }

        // POST: Proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proyecto,nombre,id_usuario,estado,interaciones")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.id_usuario);
            return View(proyecto);
        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
