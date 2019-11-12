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
    }
}