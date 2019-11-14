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

        public ActionResult ValidarI(Usuario User)
        {

            if (!ModelState.IsValid)
            {
                return View("IniciarSesion", User);
            }
            else
            {
                int idus = BD.Loguearse(User);
                if (idus > -1)
                {
                    return View("Jugador", idus);
                }
                else 
                {
                    return View("IniciarSesion", User);
                }

            }
        }

        public ActionResult ValidarR(Usuario User)
        {

            if (!ModelState.IsValid)
            {
                return View("Registrar", User);
            }
            else
            {
                bool regis =BD.ValidarDatos(User);
                if (regis == true)
                {

                  BD.Registrarse(User);
                    return View("IniciarSesion", User);
                   
                    
                }
                else
                {
                    return View("Registrar", User);
                }

            }
 
        }

        public ActionResult IniciarSesion()
        {

            return View();
        }

        public ActionResult Registrar()
        {

            List<Localidad> sex = new List<Localidad>();
            sex.Add(new Localidad("Masculino"));
            sex.Add(new Localidad("Femenino"));
            ViewBag.sex = sex;

            List<Localidad> loc = new List<Localidad>();
            loc.Add(new Localidad("Avellaneda"));
            loc.Add(new Localidad("Balvanera"));
            loc.Add(new Localidad("Recoleta"));
            loc.Add(new Localidad("Palermo"));
            loc.Add(new Localidad("Paternal"));
            loc.Add(new Localidad("Caballito"));
            ViewBag.loc = loc;

            return View();
        }

        public ActionResult Jugador(int idus)
        {
            ViewBag.Jugador = BD.TraerUsuario(idus);


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
