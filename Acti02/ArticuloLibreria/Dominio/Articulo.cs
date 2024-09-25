using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticuloLibreria.Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Art { get; set; }
        public bool Estado { get; set; }


        public Articulo()
        {

        }
    }
}
