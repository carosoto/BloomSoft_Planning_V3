using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloomSoft_V2.Models;
using Microsoft.AspNet.Identity;

namespace BloomSoft_V2.Controllers
{
    //controlador del modelo de requerimiento
    public class RequerimientoController : Controller
    {
        private BSModel db = new BSModel();

        //visualizar los atributos de la tabla requerimiento
        // GET: Requerimiento
        public ActionResult Index()
        {
            var requerimiento = db.Requerimiento.Include(r => r.Proyecto);
            return View(requerimiento.ToList());
        }

        //visualizar los detalles de los atributos de la tabla rquerimiento
        // GET: Requerimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        //crear los atributos de la tabla requerimiento
        // GET: Requerimiento/Create
        public ActionResult Create()
        {
            var currentUser = User.Identity.GetUserId();
            var proy = db.Proyecto.ToList().Where(d => d.id_usuario == currentUser);
            var proylist = db.Proyecto.ToList();
            var buscar = db.Proyecto.ToList().Where(d=>d.id_proyecto==proylist[proylist.Count-1].id_proyecto);

            ViewBag.id_proyecto = new SelectList(buscar, "id_proyecto", "nombre");
            return View();
        }

        // POST: Requerimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_requerimiento,id_proyecto,descripcion")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Requerimiento.Add(requerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", requerimiento.id_proyecto);
            return View(requerimiento);
        }

        //editar los atributos de la tabla requerimiento
        // GET: Requerimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", requerimiento.id_proyecto);
            return View(requerimiento);
        }

        // POST: Requerimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_requerimiento,id_proyecto,descripcion")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", requerimiento.id_proyecto);
            return View(requerimiento);
        }

        //eliminar los atributos de la tabla requerimiento
        // GET: Requerimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        //confirmar la eliminacion de los atributos de la tabla requerimiento
        // POST: Requerimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            db.Requerimiento.Remove(requerimiento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //acceso a la base de datos
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
