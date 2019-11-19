using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace maketeam.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string NombreDeUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Más de 6 letras y menos de 15 ")]
        public string Contraseña { get; set; }
        public int Edad { get; set; }
        public string Localidad { get; set; }
        public string Sexo { get; set; }

        public Usuario(int idusuario, string nombredeusuario, string correoelectronico, string contraseña, int edad, string localidad, string sexo)
        {
            IDUsuario = idusuario;
            NombreDeUsuario = nombredeusuario;
            CorreoElectronico = correoelectronico;
            Contraseña = contraseña;
            Edad = edad;
            Localidad = localidad;
            Sexo = sexo;
        }
        public Usuario()
        {
        }
    }                  
}                      
                       