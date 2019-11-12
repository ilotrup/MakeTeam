using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace maketeam.Models
{
    public static class BD
    {
        private static SqlConnection Conectar()
        {
            string constring = "Server=.; DataBase = MakeTeam; Trusted_Connection = true;";
            SqlConnection a = new SqlConnection(constring);
            a.Open();
            return a;
        }

        private static void Desconectar(SqlConnection con)
        {
            con.Close();
        }

        public static Boolean Loguearse(Usuario User)
        {
            bool Logueado;
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "Select * from Usuarios where NombreDeUsuario LIKE '" + User.NombreDeUsuario + "' and Contraseña LIKE '" + User.Contraseña + "'";
            SqlDataReader lector = consulta.ExecuteReader();
            Usuario Us = new Usuario();
            if (lector.Read())
            {
                Logueado = true;
            }
            else
            {
                Logueado = false;
            }
            return Logueado;
        }

        public static Boolean ValidarDatos(Usuario User)
        {
            bool Validar;
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "Select * from Usuarios where NombreDeUsuario = '" + User.NombreDeUsuario + "'";
            SqlDataReader lector = consulta.ExecuteReader();
            Usuario Us = new Usuario();
            if (lector.Read())
            {
                Validar = false;
            }
            else
            {
                Logueado = true;
            }

            SqlCommand consulta2 = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "Select * from Usuarios where CorreoElectronico = '" + User.CorreoElectronico + "'";
            SqlDataReader lector = consulta.ExecuteReader();
            Usuario Us = new Usuario();
            if (lector.Read())
            {
                Validar = false;
            }
            else
            {
                Logueado = true;
            }

            return Validar;
        }
        public static void Registrarse(Usuario User)
        {
            bool Registrado;
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "INSERT into Usuarios(IDUsuario,NombreDeUsuario,CorreoElectronico," +
                "Contraseña,Edad,Localidad,Sexo) values ('" + User.NombreDeUsuario + "','" + User.CorreoElectronico + "'," +
                "'" + User.Contraseña + "','" + User.Edad + "','"  + User.Localidad + "','" + User.Sexo + "')";
            SqlDataReader lector = consulta.ExecuteNonQuery();
        }
    }
}