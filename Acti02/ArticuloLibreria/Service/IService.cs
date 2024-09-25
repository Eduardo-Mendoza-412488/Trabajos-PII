using ArticuloLibreria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticuloLibreria.Service
{
    public interface IService
    {
        public bool DarBaja(int ID);
        public List<Articulo> ObtenerArticulos();
        public Articulo ObtenerArticulo(int ID);
        public bool GuardarArticulo(Articulo oArticulo);
    }
}
