using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class Usuario
    {
        private int IDUsuario;
        private string NombreDeUsuario;
        private string CorreoElectronico;
        private string Contraseña;
        private int Edad;
        private string Localidad;
        private string Sexo;

        public int IDUsuario1 { get => IDUsuario; set => IDUsuario = value; }
        public string NombreDeUsuario1 { get => NombreDeUsuario; set => NombreDeUsuario = value; }
        public string CorreoElectronico1 { get => CorreoElectronico; set => CorreoElectronico = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string Localidad1 { get => Localidad; set => Localidad = value; }
        public string Sexo1 { get => Sexo; set => Sexo = value; }

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
                       