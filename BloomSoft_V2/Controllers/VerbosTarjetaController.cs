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
    public class VerbosTarjetaController : Controller
    {
        private BSModel db = new BSModel();

        // GET: VerbosTarjeta
        public ActionResult Index()
        {
            var verbosTarjeta = db.VerbosTarjeta.Include(v => v.TarjetaRequerim).Include(v => v.Verbotax);
            return View(verbosTarjeta.ToList());
        }

        // GET: VerbosTarjeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VerbosTarjeta verbosTarjeta = db.VerbosTarjeta.Find(id);
            if (verbosTarjeta == null)
            {
                return HttpNotFound();
            }
            return View(verbosTarjeta);
        }

        // GET: VerbosTarjeta/Create
        public ActionResult Create()
        {
            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim");
            ViewBag.id_verbo = new SelectList(db.Verbotax, "id_verbo", "verbos");
            return View();
        }

        // POST: VerbosTarjeta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_verbostarjeta,id_tarjetaRequerim,id_verbo")] VerbosTarjeta verbosTarjeta)
        {
            if (ModelState.IsValid)
            {
                db.VerbosTarjeta.Add(verbosTarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim", verbosTarjeta.id_tarjetaRequerim);
            ViewBag.id_verbo = new SelectList(db.Verbotax, "id_verbo", "verbos", verbosTarjeta.id_verbo);
            return View(verbosTarjeta);
        }

        // GET: VerbosTarjeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VerbosTarjeta verbosTarjeta = db.VerbosTarjeta.Find(id);
            if (verbosTarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim", verbosTarjeta.id_tarjetaRequerim);
            ViewBag.id_verbo = new SelectList(db.Verbotax, "id_verbo", "verbos", verbosTarjeta.id_verbo);
            return View(verbosTarjeta);
        }

        // POST: VerbosTarjeta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_verbostarjeta,id_tarjetaRequerim,id_verbo")] VerbosTarjeta verbosTarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verbosTarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tarjetaRequerim = new SelectList(db.TarjetaRequerim, "id_tarjetaRequerim", "id_tarjetaRequerim", verbosTarjeta.id_tarjetaRequerim);
            ViewBag.id_verbo = new SelectList(db.Verbotax, "id_verbo", "verbos", verbosTarjeta.id_verbo);
            return View(verbosTarjeta);
        }

        // GET: VerbosTarjeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VerbosTarjeta verbosTarjeta = db.VerbosTarjeta.Find(id);
            if (verbosTarjeta == null)
            {
                return HttpNotFound();
            }
            return View(verbosTarjeta);
        }

        // POST: VerbosTarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VerbosTarjeta verbosTarjeta = db.VerbosTarjeta.Find(id);
            db.VerbosTarjeta.Remove(verbosTarjeta);
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
