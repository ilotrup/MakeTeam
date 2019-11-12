using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class Equipo
    {
        private int IDEquipo;
        private string NombreEquipo;

        public int IDEquipo1 { get => IDEquipo; set => IDEquipo = value; }
        public string NombreEquipo1 { get => NombreEquipo; set => NombreEquipo = value; }

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