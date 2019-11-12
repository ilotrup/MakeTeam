using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class EquiposXUsuarios
    {
        private int IDEquipo;
        private int IDUsuario;

        public int IDEquipo1 { get => IDEquipo; set => IDEquipo = value; }
        public int IDUsuario1 { get => IDUsuario; set => IDUsuario = value; }

        public EquiposXUsuarios(int idequipo,int idusuario)
        {
            IDEquipo = idequipo;
            IDUsuario = idusuario;
        }

        public EquiposXUsuarios()
        {
        }
    }
}