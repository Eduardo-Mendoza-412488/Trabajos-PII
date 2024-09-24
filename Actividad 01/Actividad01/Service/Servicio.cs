using Actividad01.Datos;
using Actividad01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Service
{
    public class Servicio
    {
        FacturaRepository oFacturaRepo;
        public Servicio()
        {
            oFacturaRepo = new FacturaRepository();
        }

        public List<Factura> ObtenerFacturas()
        {
            return oFacturaRepo.GetAll();
        }

        public List<DetalleFactura> ObtenerDetalles(int id)
        {
            return oFacturaRepo.GetDetallesById(id);
        }

        public bool GuardarFactura(Factura oFactura)
        {
            return oFacturaRepo.Save(oFactura);
        }


        public bool GuardarDetalles(DetalleFactura oDetalle)
        {
            return oFacturaRepo.InsertarDetalles(oDetalle);
        }

        public bool DarBaja(int id)
        {
            return oFacturaRepo.Delete(id);
        }
    }
}
