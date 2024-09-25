using ArticuloLibreria.Datos;
using ArticuloLibreria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArticuloLibreria.Service
{
    public class Service : IService
    {
        private IRepositoryArticulo repo;

        public Service()
        {
            repo = new RepositoryArticulo();
        }

        public bool DarBaja(int ID)
        {
            return repo.Delete(ID);
        }

        public List<Articulo> ObtenerArticulos()
        {
            return repo.GetAll();
        }

        public bool GuardarArticulo(Articulo oArticulo)
        {
            return repo.Save(oArticulo);
        }

        public Articulo ObtenerArticulo(int ID)
        {
            return repo.GetById(ID);
        }
    }
    
}
