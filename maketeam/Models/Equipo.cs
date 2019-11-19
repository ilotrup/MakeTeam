using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class Equipo
    {


        public int IDEquipo { get; set; }
        public string NombreEquipo { get; set; }

        public Equipo(int idequipo, string nombreequipo)
        {
            IDEquipo = idequipo;
            NombreEquipo = nombreequipo;
        }
        public Equipo()
        {
        }
    }
}