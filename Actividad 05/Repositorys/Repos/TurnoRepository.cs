using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosLibreria.Models;

namespace Repositorys.Repos
{
    public class TurnoRepository : ITurnosRepository
    {
        private TurnosContext _context;

        public TurnoRepository(TurnosContext context)
        {
            _context = context;
        }
        public bool DarBaja(int id)
        {
            var entity = _context.TTurnos.Find(id);
            if (entity == null) { return false; }
            entity.Activo = false;
            _context.TTurnos.Update(entity);
            return _context.SaveChanges() > 0;
        }

        public List<TTurno> GetTurnos()
        {
            return _context.TTurnos.ToList();
        }

        public bool Save(TTurno turno)
        {
          


            //try
            //{
                _context.TTurnos.Add(turno);
                foreach (TDetallesTurno detail in turno.TDetallesTurnos)
                {
                    detail.IdTurno = turno.Id;
                    _context.TDetallesTurnos.Add(detail);
                }
                _context.SaveChanges();
 
                return true;
            //}
            //catch (Exception)
            //{

            //    
            //    return false;
            //}
        }

        public bool Update(int id, TTurno turno)
        {
            var entity = _context.TTurnos.Find(id);
            entity.Fecha = turno.Fecha;
            entity.Hora = turno.Hora;
            entity.Cliente = turno.Cliente;
            _context.TTurnos.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
