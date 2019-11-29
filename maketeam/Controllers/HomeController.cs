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
            ViewBag.Descripcion1 = "Hola Guarda y accede a tus equipos ya armados . ¡Ojo! Hay una cantida maxima de equipos por persona, ¡no te lo pierdas!";
            ViewBag.Descripcion2 = "¿Queres tener un equipo soñado con tus amigos?";
            ViewBag.Descripcion22 = "Con este sitio todo es posible. Ingresando tus datos ya vas a poder cumplir tu sueño.";
            ViewBag.Fondo = "Fondo.jpg";
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            return View();

        }

        public ActionResult quienes()
        {
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            ViewBag.TituloQuienes = "Nosotros somos MakeTeam, un grupo de 4 amigos que queremos resolver una problematica.";
            ViewBag.DescripcionQuienes = "Nuestra idea empieza de una experiencia cuando no completabamos equipo para ir a jgar al futbol. Con esta problematica pudimos crear esto. NOsotros queremos beneficiar a todo tipo de personas ya que como les puede pasar a ustedes, tambien nos puede pasar a nosotros.";
            ViewBag.FotoAle = "";
            ViewBag.FotoIlan = "";
            ViewBag.FotoGluk = "";
            ViewBag.FotoNico = "";
            ViewBag.LogoQuienes = "LogoMakeTeam1.jpg";



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
                int IdUsuario = BD.Loguearse(User);
                if (IdUsuario > -1)
                {
                    Session["usuarioact"] = IdUsuario;
                    return RedirectToAction("Jugador",new { idus = IdUsuario });
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

                return View("Registrar",User);
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
                    return RedirectToAction("Registrar");
                }

            }
 
        }

        public ActionResult IniciarSesion()
        {
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            return View();
        }

        public ActionResult Registrar()
        {
            ViewBag.Logo = "LogoMakeTeam1.jpg";
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
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            //+



            //  Equipos
            List<Equipo> equip = new List<Equipo>();
            equip = BD.TraerEquipos(idus);
            ViewBag.Jugador = BD.TraerUsuario(idus);
            ViewBag.Equipos = equip;
            ViewBag.id = idus;


            return View();
        }

        public ActionResult CrearEquipo()
        {
            // Para prox clase faltan los filtros
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            return View();
        }

        public ActionResult ValidarE(Equipo equi)
        {

            if (!ModelState.IsValid)
            {
                return View("CrearEquipo");
            }
            else
            {
                bool regis1 = BD.ValidarEquipo(equi);
                if (regis1 == false)
                {

                    BD.NuevoEquipo(equi.NombreEquipo);
                    int IDEquip = BD.TraerIDEquipo(equi.NombreEquipo);
                    Session["equipact"] = IDEquip;
                    //int idusuario = Convert.ToInt32(Session["usuario"]);
                    ViewBag.Logo = "LogoMakeTeam1.jpg";
                    Usuario jugador = new Usuario();
                    jugador = BD.TraerUsuario(Convert.ToInt32(Session["usuarioact"]));
                    List<Usuario> Users = new List<Usuario>();
                    Users = BD.TraerJugadoresXLocalidad(jugador.Localidad);
                    ViewBag.Jugadores = Users;
                    return View("AgregarJugadoresAlEquipo");


                }
                else
                {
                    return RedirectToAction("CrearEquipo");
                }

            }

        }

       

        public ActionResult AgregarJugadoresAlEquipo()
        {


            return View();
        }

        [HttpPost]
        public ActionResult ValidarJXE(JugadoresXE jugs)
        {
            BD.InsertarJugadores(jugs.Jugador1, Convert.ToInt32(Session["equipact"]));
            BD.InsertarJugadores(jugs.Jugador2, Convert.ToInt32(Session["equipact"]));
            BD.InsertarJugadores(jugs.Jugador3, Convert.ToInt32(Session["equipact"]));
            BD.InsertarJugadores(jugs.Jugador4, Convert.ToInt32(Session["equipact"]));
            BD.InsertarJugadores(jugs.Jugador5, Convert.ToInt32(Session["equipact"]));
            return RedirectToAction("Jugador", new { idus = Convert.ToInt32(Session["usuarioact"]) });
        }


        public ActionResult MostrarEquipo (int idequip)
        {
            ViewBag.Equi = BD.TraerNombreEquipo(idequip);
            ViewBag.Jugs = BD.TraerEquipo(idequip);
            return View();
        }






        public ActionResult About()
        {
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Logo = "LogoMakeTeam1.jpg";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
