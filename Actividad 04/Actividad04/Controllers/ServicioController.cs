using LibreríaTurnos.Repositorys;
using ModeloTurnos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actividad04.Controllers
{
    [ApiController]
    [Route("Servicio")]
    public class ServicioController : ControllerBase
    {

        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }


        [HttpGet]
        [Route("Recuperar")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _servicioRepository.GetServiciosAsync());
        }

        [HttpGet]
        [Route("FiltrarPrecio")]
        public async Task<IActionResult> GetPrecioMayor([FromQuery] int precio)
        {
            var servicios = await _servicioRepository.GetServiciosByPrecioMayorAsync(precio);
            return Ok(servicios);
        }

        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> Post([FromBody] Servicio oServicio)
        {
            return Ok(await _servicioRepository.Save(oServicio));
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Put([FromBody] Servicio oServicio, int id)
        {
            return Ok(await _servicioRepository.Update(oServicio, id));
        }


        //POST: ServicioController/Create
    }
}
