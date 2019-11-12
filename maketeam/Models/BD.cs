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
            string constring = "Server=.; DataBase = Juego; Trusted_Connection = true;";
            SqlConnection a = new SqlConnection(constring);
            a.Open();
            return a;
        }

        private static void Desconectar(SqlConnection con)
        {
            con.Close();
        }
    }
}