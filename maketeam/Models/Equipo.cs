using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace maketeam.Models
{
    public class Equipo
    {


        public int IDEquipo { get; set; }
        [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
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