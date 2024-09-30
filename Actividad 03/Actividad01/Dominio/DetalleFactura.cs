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
        public int NroFactura { get; set; }
        public Articulo Art { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura( int nro_factura,int id, int art)
        {
            Id = id;
            NroFactura = nro_factura;
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
