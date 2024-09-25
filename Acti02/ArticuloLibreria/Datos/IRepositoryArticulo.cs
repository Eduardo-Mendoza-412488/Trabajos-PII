using ArticuloLibreria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticuloLibreria.Datos
{
    public interface IRepositoryArticulo
    {
        List<Articulo> GetAll();
        Articulo GetById(int id);
        bool Save(Articulo oArticulo);
        bool Delete(int id);
    }
}
