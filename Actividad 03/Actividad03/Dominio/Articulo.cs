using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Dominio
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Articulo()
        {

        }


        public override string ToString()
        {
            return Nombre;
        }
    }
}
