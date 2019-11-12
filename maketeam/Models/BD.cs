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
            if (lector.Read())
            {
                Validar = false;
            }
            else
            {
                Validar = true;
            }

            SqlCommand consulta2 = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "Select * from Usuarios where CorreoElectronico = '" + User.CorreoElectronico + "'";
            SqlDataReader Lector = consulta.ExecuteReader();
            if (Lector.Read())
            {
                Validar = false;
            }
            else
            {
                Validar = true;
            }
            Con.Close();
            return Validar;
        }

        public static void Registrarse(Usuario User)
        {
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "INSERT into Usuarios(IDUsuario,NombreDeUsuario,CorreoElectronico," +
                "Contraseña,Edad,Localidad,Sexo) values ('" + User.NombreDeUsuario + "','" + User.CorreoElectronico + "'," +
                "'" + User.Contraseña + "','" + User.Edad + "','"  + User.Localidad + "','" + User.Sexo + "')";
            consulta.ExecuteNonQuery();
        }

        public static void Traerusuario(int ID)
        {
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT from Usuarios where IDUsuario = '" + ID + "'";
            SqlDataReader lector = consulta.ExecuteReader();
            Usuario User = new Usuario();
            if (lector.Read())
            {
                int idusuario = Convert.ToInt32(lector["IDUsuario"]);
                string nombreusuario = lector["TextoPregunta"].ToString();
                string correoelectronico = lector["Dificultad"].ToString();
                string contraseña = lector["IDUsuario"].ToString();
                int edad = Convert.ToInt32(lector["TextoPregunta"]);
                string localidad = lector["Dificultad"].ToString();
                string sexo = lector["IDUsuario"].ToString();
                User = new Usuario(idusuario, nombreusuario, correoelectronico, contraseña, edad, localidad, sexo);
            }
        }
    }
}