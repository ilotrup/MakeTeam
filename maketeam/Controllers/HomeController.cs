﻿using System;
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
            ViewBag.Fondo = "Fondo.jpg";
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

            //+

           
            
            //  Equipos
            List<Equipo> equip = new List<Equipo>();
            equip = BD.TraerEquipos(idus);
            ViewBag.Jugador = BD.TraerUsuario(idus);
            ViewBag.Equipos = equip;
            ViewBag.id = idus;


            return View();
        }

        public ActionResult CrearEquipo(int idusuario)
        {
            // Para prox clase faltan los filtros

            return View();
        }

        public ActionResult ValidarE(Equipo equi,string nombreequipo)
        {

            if (!ModelState.IsValid)
            {
                return View("Jugador", equi);
            }
            else
            {
                bool regis1 = BD.ValidarEquipo(equi);
                if (regis1 == true)
                {

                    BD.NuevoEquipo(nombreequipo);
                    return View("IniciarSesion", User);


                }
                else
                {
                    return RedirectToAction("Registrar");
                }

            }

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
