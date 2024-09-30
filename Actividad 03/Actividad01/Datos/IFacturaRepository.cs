using Actividad01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Datos
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();
        List<DetalleFactura> GetDetallesById(int id);
        bool Save(Factura oFactura);
        bool InsertarDetalles(DetalleFactura oDetalle);
        bool Delete(int id);
    }
}
