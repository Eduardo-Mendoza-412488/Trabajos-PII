using TurnosLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Repos
{
    public interface ITurnosRepository
    {
        List<TTurno> GetTurnos();
        bool Save(TTurno turno);
        bool Update(int id,TTurno turno);
        bool DarBaja(int id);
    }
}
