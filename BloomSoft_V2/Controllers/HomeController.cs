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

            var partJuego = new Tablero
            {
                JugadorModel = db.PartidaJugador,
            
            };
            if (partJuego == null)
            {
                return RedirectToAction("Index", "HomeController");
            }
            return View(partJuego);
        }
        /*//Funcion para cambiar el turno
        public ActionResult GameBoard(int id_part)
        {
            var part = db.PartidaJugador.Where(x => x.id_partidaJuego == id_part);
            int cantidad = 0;
            int contador = 0;
            int contador2 = 0;
            foreach (var registros in part)
                cantidad++;
            foreach (var partida in part)
            {
                contador++;
                if (partida.turno == true)
                    db.PartidaJugador.Find(partida.id_partidaJugador).turno = false;
                if (contador == cantidad)
                    contador = 1;
            }
            foreach (var partida in part)
            {
                contador2++;
                if (contador + 1 == contador2)
                    db.PartidaJugador.Find(partida.id_partidaJugador).turno = true;
            }
            db.SaveChanges();

            var partJuego = db.PartidaJugador;
            if (partJuego == null)
            {
                return RedirectToAction("Index", "HomeController");
            }
            return View(partJuego);
        }
        */

        //[Authorize]
        /*
        public ActionResult ContinuarPartida()
        {


            var partidaJugador = db.PartidaJugador;
            if (partidaJugador == null)
            {
                return RedirectToAction("Index", "HomeController");

            }
            return View(partidaJugador);
        }
        */
    }

}