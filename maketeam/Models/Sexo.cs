using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class Sexo
    {
        public string Nombre { get; set; }

        public Sexo()
        {

        }

        public Sexo(string Nom)
        {
            Nombre = Nom;
        }
    }
}