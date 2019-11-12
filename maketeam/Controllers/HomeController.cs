using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using maketeam.Models;

namespace maketeam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Descripcion1 = "Guarda y accede a tus equipos ya armados . ¡Ojo! Hay una cantida maxima de equipos por persona, ¡no te lo pierdas!";
            ViewBag.Descripcion2 = "¿Queres tener un equipo soñado con tus amigos?";
            ViewBag.Descripcion22 = "Con este sitio todo es posible. Ingresando tus datos ya vas a poder cumplir tu sueño.";
            return View();
        }

        public ActionResult Validar(Usuario User)
        {

            if (!ModelState.IsValid)
            {
                return View("IniciarSesion", User);
            }
            else
            {
                bool logueo = BD.Loguearse(User);
                if (logueo == true)
                {
                    return RedirectToAction("Index", "BackOffice", User);
                }
                else
                {
                    return View("IniciarSesion", User);
                }

            }



        }

        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
