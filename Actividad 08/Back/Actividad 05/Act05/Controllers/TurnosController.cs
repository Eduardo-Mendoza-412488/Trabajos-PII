using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositorys.Repos;
using TurnosLibreria.Models;

namespace Act05.Controllers
{
    [ApiController]
    [Route("Turnos")]
    public class TurnosController : ControllerBase
    {
        private ITurnosRepository _repository;

        public TurnosController(TurnoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Recuperar")]
        public IActionResult Get()
        {
            return Ok(_repository.GetTurnos());
        }

        [HttpPost]
        [Route("Insertar")]
        public IActionResult Post(TTurno turno)
        {
            return Ok(_repository.Save(turno));
        }

        [HttpPut]
        [Route("Insertar")]
        public IActionResult Put(int id,[FromBody] TTurno turno)
        {
            return Ok(_repository.Update(id, turno));
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Delete(int id)
        {
            return Ok(_repository.DarBaja(id));
        }



    }
}
