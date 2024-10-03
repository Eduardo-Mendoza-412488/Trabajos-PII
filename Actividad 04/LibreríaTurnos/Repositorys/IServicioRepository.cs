using Microsoft.EntityFrameworkCore;
using ModeloTurnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreríaTurnos.Repositorys
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetServiciosByPrecioMayorAsync(int precioMinimo);
        Task<List<Servicio>> GetServiciosAsync();

        Task<bool> Save(Servicio oServ);
        Task<bool> Update(Servicio oServ, int id);
    }
}
