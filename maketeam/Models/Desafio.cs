using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class Desafio
    {
        private int IDDesafio;
        private int IDEquipo1;
        private int IDEquipo2;
        private DateTime FechaDeEncuentro;

        public int IDDesafio1 { get => IDDesafio; set => IDDesafio = value; }
        public int IDEquipo11 { get => IDEquipo1; set => IDEquipo1 = value; }
        public int IDEquipo21 { get => IDEquipo2; set => IDEquipo2 = value; }
        public DateTime FechaDeEncuentro1 { get => FechaDeEncuentro; set => FechaDeEncuentro = value; }

        public Desafio(int iddesafio, int idequipo1, int idequipo2, DateTime fechadeencuentro)
        {
            IDDesafio = iddesafio;
            IDEquipo1 = idequipo1;
            IDEquipo2 = idequipo2;
            FechaDeEncuentro = fechadeencuentro;
        }
        public Desafio()
        {
        }

    }
}