using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Dominio
{
    public class Factura
    {
        public int Id { get; set; }
        public List<DetalleFactura> Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormPago { get; set; }
        public string Cliente { get; set; }
        public bool Activo { get; set; }



        public Factura()
        {
            Detalle = new List<DetalleFactura>();
        }

        public override string ToString()
        {
            return Id + " | " + Fecha + " | " + FormPago.ToString() + " | " + Cliente + " | Activo: " + Activo;
        }

        public void AgregarArticulo(int IdArt, List<DetalleFactura> list)
        {
            if(list == null)
            {
                var oDetail1 = new DetalleFactura();
                oDetail1.Art = new Articulo();
                oDetail1.Art.Codigo = IdArt;
                oDetail1.Cantidad++;
                list.Add(oDetail1);
            }
            bool aux = false;
            foreach (DetalleFactura detail in list)
            {

                if (detail.Art.Codigo == IdArt)
                {
                    aux = true;
                    detail.Cantidad++;
                    break;
                }
            }
            if(aux == false)
            {
                var oDetail = new DetalleFactura();
                oDetail.Art = new Articulo();
                oDetail.Art.Codigo = IdArt;
                oDetail.Cantidad++;
                list.Add(oDetail);
            }
          
        }
    }
}
