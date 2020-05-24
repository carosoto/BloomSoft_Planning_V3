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
    public class VerbotaxController : Controller
    {
        private BSModel db = new BSModel();

        // GET: Verbotax
        public ActionResult Index()
        {
            var verbotax = db.Verbotax.Include(v => v.Taxonomia);
            return View(verbotax.ToList());
        }

        // GET: Verbotax/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verbotax verbotax = db.Verbotax.Find(id);
            if (verbotax == null)
            {
                return HttpNotFound();
            }
            return View(verbotax);
        }

        // GET: Verbotax/Create
        public ActionResult Create()
        {
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria");
            return View();
        }

        // POST: Verbotax/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_verbo,nivel_tax,verbos")] Verbotax verbotax)
        {
            if (ModelState.IsValid)
            {
                db.Verbotax.Add(verbotax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria", verbotax.nivel_tax);
            return View(verbotax);
        }

        // GET: Verbotax/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verbotax verbotax = db.Verbotax.Find(id);
            if (verbotax == null)
            {
                return HttpNotFound();
            }
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria", verbotax.nivel_tax);
            return View(verbotax);
        }

        // POST: Verbotax/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_verbo,nivel_tax,verbos")] Verbotax verbotax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verbotax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nivel_tax = new SelectList(db.Taxonomia, "nivel_tax", "categoria", verbotax.nivel_tax);
            return View(verbotax);
        }

        // GET: Verbotax/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verbotax verbotax = db.Verbotax.Find(id);
            if (verbotax == null)
            {
                return HttpNotFound();
            }
            return View(verbotax);
        }

        // POST: Verbotax/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verbotax verbotax = db.Verbotax.Find(id);
            db.Verbotax.Remove(verbotax);
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
