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
    public class ParticipantesController : Controller
    {
        private BSModel db = new BSModel();

        // GET: Participantes
        public ActionResult Index()
        {
            var participante = db.Participante.Include(p => p.AspNetUsers).Include(p => p.Proyecto);
            return View(participante.ToList());
        }

        // GET: Participantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: Participantes/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            return View();
        }

        // POST: Participantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_participante,id_proyecto,id_usuario,tipo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Participante.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", participante.id_usuario);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", participante.id_proyecto);
            return View(participante);
        }

        // GET: Participantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", participante.id_usuario);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", participante.id_proyecto);
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_participante,id_proyecto,id_usuario,tipo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", participante.id_usuario);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", participante.id_proyecto);
            return View(participante);
        }

        // GET: Participantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participante participante = db.Participante.Find(id);
            db.Participante.Remove(participante);
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
        
        [HttpGet]
        public ActionResult Unirse([Bind(Include = "id_proyecto")] Participante participante)
        {
            var valido = true;
            var proyectos = db.Proyecto;
            var participantes = db.Participante;
            if (participante.id_proyecto != 0)
            {
                foreach (var itParticipante in participantes)
                {
                    if (itParticipante.id_proyecto == participante.id_proyecto && itParticipante.id_usuario == User.Identity.GetUserId())
                    {
                        valido = false;
                    }
                }
                if(valido == true)
                {
                    valido = false;
                    foreach (var itProyecto in proyectos)
                    {
                        if (itProyecto.id_proyecto == participante.id_proyecto)
                            valido = true;
                    }
                    if (valido == true)
                    {
                        participante.id_usuario = User.Identity.GetUserId();
                        participante.tipo = 1;
                        db.Participante.Add(participante);
                        db.SaveChanges();
                        foreach (var itProyecto in proyectos)
                        {
                            if (itProyecto.id_proyecto == participante.id_proyecto)
                                return View(itProyecto);
                        }
                    }
                }
            }
            return RedirectToAction("Menu", "Home");
        }
        
    }
}
