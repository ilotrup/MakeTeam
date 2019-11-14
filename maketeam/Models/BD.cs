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

        public static int Loguearse(Usuario User)
        {
            int idus = -1;
            bool Logueado;
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "Select IDUsuario from Usuarios where NombreDeUsuario LIKE '" + User.NombreDeUsuario + "' and Contraseña LIKE '" + User.Contraseña + "'";
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read())
            {

                idus = Convert.ToInt32(lector["IDUsuario"]);
            }
            
            return idus;
        }

        public static Usuario TraerUsuario(int ID)
        {
            SqlConnection Con = Conectar();
            SqlCommand consulta = Con.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "Select * from Usuarios where IDUsuario = " + ID;
            SqlDataReader dataReader = consulta.ExecuteReader();
            Usuario us = new Usuario();
            while (dataReader.Read())
            {

                us.IDUsuario = Convert.ToInt32(dataReader["IDUsuario"]);
                us.Edad = Convert.ToInt32(dataReader["Edad"]);
                us.NombreDeUsuario = dataReader["NombreDeUsuario"].ToString();
                us.CorreoElectronico = dataReader["CorreoElectronico"].ToString();
                us.Contraseña = dataReader["Contraseña"].ToString();
                us.Localidad = dataReader["Localidad"].ToString();
                us.Sexo = dataReader["Sexo"].ToString();
            }
            Con.Close();
            return us;
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