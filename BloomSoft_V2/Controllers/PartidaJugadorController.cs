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
            var currentUser = User.Identity.GetUserId();
            var usuario = db.AspNetUsers.ToList().Where(d => d.Id == currentUser);
            ViewBag.id_usuario = new SelectList(usuario, "Id", "Email");
            var partidajuego = db.PartidaJuego.ToList().Where(d => d.id_usuario == currentUser);
            ViewBag.id_partidaJuego = new SelectList(partidajuego, "id_partidaJuego", "id_usuario");
            ViewBag.puntos = 0;
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
                return RedirectToAction("GameBoard", "Home");
            }

            var currentUser = User.Identity.GetUserId();
            var usuario = db.AspNetUsers.ToList().Where(d => d.Id == currentUser);
            ViewBag.id_usuario = new SelectList(usuario, "Id", "Email", partidaJugador.id_usuario);
            var partidajuego = db.PartidaJuego.ToList().Where(d => d.id_usuario == currentUser);
            ViewBag.id_partidaJuego = new SelectList(partidajuego, "id_partidaJuego", "id_usuario", partidaJugador.id_partidaJuego);
            ViewBag.puntos = 0;
            return View(partidaJugador);
        }

        [HttpGet]
        public ActionResult UnirsePartida([Bind(Include = "id_partidaJuego")] PartidaJugador partida)
        {
            var valido = true;
            var juegos = db.PartidaJuego;
            var partidajugador = db.PartidaJugador;
            if (partida.id_partidaJuego != 0)
            {
                foreach (var itPartidaJug in partidajugador)
                {
                    if (itPartidaJug.id_partidaJuego == partida.id_partidaJuego && itPartidaJug.id_usuario == User.Identity.GetUserId())
                    {
                        valido = false;
                    }
                }
                if (valido == true)
                {
                    valido = false;
                    foreach (var itJuegos in juegos)
                    {
                        if (itJuegos.id_partidaJuego == partida.id_partidaJuego)
                            valido = true;
                    }
                    if (valido == true)
                    {
                        partida.id_usuario = User.Identity.GetUserId();
                        partida.puntos = 0;
                        partida.turno = false;
                        db.PartidaJugador.Add(partida);
                        db.SaveChanges();
                        return RedirectToAction("GameBoard", "Home");
                    }
                }
            }
            return RedirectToAction("Menu", "Home");
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
