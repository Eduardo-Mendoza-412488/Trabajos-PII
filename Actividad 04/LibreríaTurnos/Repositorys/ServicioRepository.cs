using Microsoft.EntityFrameworkCore;
using ModeloTurnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreríaTurnos.Repositorys
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ApplicationDbContext _context;

        public ServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetServiciosByPrecioMayorAsync(int precioMinimo)
        {
            return await _context.Servicios
                .Where(servicio => servicio.Monto > precioMinimo)
                .ToListAsync();
        }

        public async Task<List<Servicio>> GetServiciosAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<bool> Save(Servicio oServ)
        {
            _context.Servicios.Add(oServ);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Servicio servicio, int id)
        {
            var entity = _context.Servicios.Find(id);
            if (entity == null) return false;
            entity.Nombre = servicio.Nombre;
            entity.Promocion = servicio.Promocion;
            entity.Monto = servicio.Monto;
            _context.Servicios.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
