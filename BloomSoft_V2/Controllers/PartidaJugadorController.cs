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
    public class PartidaJugadorController : Controller
    {
        private BSModel db = new BSModel();

        // GET: PartidaJugador
        public ActionResult Index()
        {
            var partidaJugador = db.PartidaJugador.Include(p => p.AspNetUsers).Include(p => p.PartidaJuego);
            return View(partidaJugador.ToList());
        }

        // GET: PartidaJugador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidaJugador partidaJugador = db.PartidaJugador.Find(id);
            if (partidaJugador == null)
            {
                return HttpNotFound();
            }
            return View(partidaJugador);
        }

        // GET: PartidaJugador/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_partidaJuego = new SelectList(db.PartidaJuego, "id_partidaJuego", "id_usuario");
            return View();
        }

        // POST: PartidaJugador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_partidaJugador,id_partidaJuego,id_usuario,puntos")] PartidaJugador partidaJugador)
        {
            if (ModelState.IsValid)
            {
                db.PartidaJugador.Add(partidaJugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", partidaJugador.id_usuario);
            ViewBag.id_partidaJuego = new SelectList(db.PartidaJuego, "id_partidaJuego", "id_usuario", partidaJugador.id_partidaJuego);
            return View(partidaJugador);
        }

        // GET: PartidaJugador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidaJugador partidaJugador = db.PartidaJugador.Find(id);
            if (partidaJugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", partidaJugador.id_usuario);
            ViewBag.id_partidaJuego = new SelectList(db.PartidaJuego, "id_partidaJuego", "id_usuario", partidaJugador.id_partidaJuego);
            return View(partidaJugador);
        }

        // POST: PartidaJugador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_partidaJugador,id_partidaJuego,id_usuario,puntos")] PartidaJugador partidaJugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partidaJugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", partidaJugador.id_usuario);
            ViewBag.id_partidaJuego = new SelectList(db.PartidaJuego, "id_partidaJuego", "id_usuario", partidaJugador.id_partidaJuego);
            return View(partidaJugador);
        }

        // GET: PartidaJugador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidaJugador partidaJugador = db.PartidaJugador.Find(id);
            if (partidaJugador == null)
            {
                return HttpNotFound();
            }
            return View(partidaJugador);
        }

        // POST: PartidaJugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartidaJugador partidaJugador = db.PartidaJugador.Find(id);
            db.PartidaJugador.Remove(partidaJugador);
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
