using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class Localidad
    {
        public string Nombre { get; set; }

        public Localidad()
        {

        }

        public Localidad(string Nom)
        {
            Nombre = Nom;
        }
    }
}