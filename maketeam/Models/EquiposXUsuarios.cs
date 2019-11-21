using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maketeam.Models
{
    public class EquiposXUsuarios
    {
       

        public int IDEquipo { get => IDEquipo; set => IDEquipo = value; }
        public int IDUsuario { get => IDUsuario; set => IDUsuario = value; }

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