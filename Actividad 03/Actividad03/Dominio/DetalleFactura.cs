using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Dominio
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public Factura NroFactura { get; set; }     
        public Articulo Art { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura(int id, int art)
        {
            Id = id;
            NroFactura = null;
            Art = null;
            Cantidad = 0;
        }

        public DetalleFactura()
        {

        }

        public override string ToString()
        {
            return "---------"+Art.ToString() + " | " + Cantidad;
        }

    }
}
