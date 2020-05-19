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
    public class PartidaJuegoController : Controller
    {
        private BSModel db = new BSModel();

        // GET: PartidaJuego
        public ActionResult Index()
        {
            var partidaJuego = db.PartidaJuego.Include(p => p.AspNetUsers).Include(p => p.Proyecto);
            return View(partidaJuego.ToList());
        }

        // GET: PartidaJuego/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidaJuego partidaJuego = db.PartidaJuego.Find(id);
            if (partidaJuego == null)
            {
                return HttpNotFound();
            }
            return View(partidaJuego);
        }

        // GET: PartidaJuego/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            return View();
        }

        // POST: PartidaJuego/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_partidaJuego,id_proyecto,id_usuario,fecha,hora")] PartidaJuego partidaJuego)
        {
            if (ModelState.IsValid)
            {
                db.PartidaJuego.Add(partidaJuego);
                db.SaveChanges();
                return RedirectToAction("GameBoard","Home");
            }

            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", partidaJuego.id_usuario);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", partidaJuego.id_proyecto);
            return View(partidaJuego);
        }

        // GET: PartidaJuego/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidaJuego partidaJuego = db.PartidaJuego.Find(id);
            if (partidaJuego == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", partidaJuego.id_usuario);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", partidaJuego.id_proyecto);
            return View(partidaJuego);
        }

        // POST: PartidaJuego/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_partidaJuego,id_proyecto,id_usuario,fecha,hora")] PartidaJuego partidaJuego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partidaJuego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", partidaJuego.id_usuario);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", partidaJuego.id_proyecto);
            return View(partidaJuego);
        }

        // GET: PartidaJuego/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidaJuego partidaJuego = db.PartidaJuego.Find(id);
            if (partidaJuego == null)
            {
                return HttpNotFound();
            }
            return View(partidaJuego);
        }

        // POST: PartidaJuego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartidaJuego partidaJuego = db.PartidaJuego.Find(id);
            db.PartidaJuego.Remove(partidaJuego);
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
