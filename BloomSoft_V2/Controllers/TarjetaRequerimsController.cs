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
    public class TarjetaRequerimsController : Controller
    {
        private BSModel db = new BSModel();

        // GET: TarjetaRequerims
        public ActionResult Index()
        {
            
            var tarjetaRequerim = db.TarjetaRequerim.Include(t =>t.PartidaJugador).Include(t => t.Requerimiento).Include(t => t.Taxonomia);
            return View(tarjetaRequerim.ToList());
        }

        // GET: TarjetaRequerims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarjetaRequerim tarjetaRequerim = db.TarjetaRequerim.Find(id);
            if (tarjetaRequerim == null)
            {
                return HttpNotFound();
            }
            return View(tarjetaRequerim);
        }

        // GET: TarjetaRequerims/Create
        public ActionResult Create()
        {
            var currentUser = User.Identity.GetUserId();
            var jugador = db.PartidaJugador.ToList().Where(d => d.id_usuario == currentUser);
            ViewBag.id_partidaJugador = new SelectList(jugador, "id_partidaJugador", "id_usuario");
            
            ViewBag.id_requerimiento = new SelectList(db.Requerimiento, "id_requerimiento", "id_proyecto");
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria");
            return View();
        }

        // POST: TarjetaRequerims/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarjetaRequerim,id_requerimiento,id_partidaJugador,nivel_tax,tiempo,dificultad,puntos")] TarjetaRequerim tarjetaRequerim)
        {
            if (ModelState.IsValid)
            {
                db.TarjetaRequerim.Add(tarjetaRequerim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var currentUser = User.Identity.GetUserId();
            var jugador = db.PartidaJugador.ToList().Where(d => d.id_usuario == currentUser);
            ViewBag.id_partidaJugador = new SelectList(jugador, "id_partidaJugador", "id_usuario", tarjetaRequerim.id_partidaJugador);
            ViewBag.id_requerimiento = new SelectList(db.Requerimiento, "id_requerimiento", "categoria", tarjetaRequerim.id_requerimiento);
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria", tarjetaRequerim.nivel_tax);
            return View(tarjetaRequerim);
        }

        // GET: TarjetaRequerims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarjetaRequerim tarjetaRequerim = db.TarjetaRequerim.Find(id);
            if (tarjetaRequerim == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_partidaJugador = new SelectList(db.PartidaJugador, "id_partidaJugador", "id_usuario", tarjetaRequerim.id_partidaJugador);
            ViewBag.id_requerimiento = new SelectList(db.Requerimiento, "id_requerimiento", "categoria", tarjetaRequerim.id_requerimiento);
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria", tarjetaRequerim.nivel_tax);
            return View(tarjetaRequerim);
        }

        // POST: TarjetaRequerims/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarjetaRequerim,id_requerimiento,id_partidaJugador,nivel_tax,tiempo,dificultad,puntos")] TarjetaRequerim tarjetaRequerim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjetaRequerim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_partidaJugador = new SelectList(db.PartidaJugador, "id_partidaJugador", "id_usuario", tarjetaRequerim.id_partidaJugador);
            ViewBag.id_requerimiento = new SelectList(db.Requerimiento, "id_requerimiento", "categoria", tarjetaRequerim.id_requerimiento);
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria", tarjetaRequerim.nivel_tax);
            return View(tarjetaRequerim);
        }

        // GET: TarjetaRequerims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarjetaRequerim tarjetaRequerim = db.TarjetaRequerim.Find(id);
            if (tarjetaRequerim == null)
            {
                return HttpNotFound();
            }
            return View(tarjetaRequerim);
        }

        // POST: TarjetaRequerims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TarjetaRequerim tarjetaRequerim = db.TarjetaRequerim.Find(id);
            db.TarjetaRequerim.Remove(tarjetaRequerim);
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
