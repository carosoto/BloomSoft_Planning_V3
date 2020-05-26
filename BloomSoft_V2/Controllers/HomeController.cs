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
    public class HomeController : Controller
    {
        private BSModel db = new BSModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Premium()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Menu()
        {
            /*ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email");
          
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
           
            ViewBag.id_partidaJuego = new SelectList(db.PartidaJuego, "id_partidaJuego", "id_usuario");*/
            return View();
        }

        /*[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Menu([Bind(Include = "id_proyecto,nombre,id_usuario,estado,interaciones")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Create","PartidaJugadorController");
            }

            ViewBag.id_usuario = new SelectList(db.AspNetUsers, "Id", "Email", proyecto.id_usuario);
            return View(proyecto);
        }*/

       

        //[Authorize]
        public ActionResult GameBoard()
        {
            
            
            var usuario = db.PartidaJuego; 
            if (usuario == null)
            {
                return RedirectToAction("Index", "HomeController");

            }
            return View(usuario);
        }

        //[Authorize]
        public ActionResult ContinuarPartida()
        {


            var partidaJuego = db.PartidaJuego;
            if (partidaJuego == null)
            {
                return RedirectToAction("Index", "HomeController");

            }
            return View(partidaJuego);
        }
    }

}