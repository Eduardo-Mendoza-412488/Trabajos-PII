using Microsoft.AspNetCore.Mvc;
using ArticuloLibreria.Service;
using ArticuloLibreria.Dominio;

namespace Act02.Controllers
{
    [ApiController]
    [Route("Articulo")]
    public class ArticuloController : ControllerBase
    {
        private IService _servicio;
        public ArticuloController()
        {
            _servicio = new Service();   
        }


        [HttpGet]
        [Route("Recuperar")]
        public IActionResult Get()
        {
            return Ok(_servicio.ObtenerArticulos());
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Post([FromBody]Articulo oArticulo)
        {
            if (oArticulo == null)
            {
                return BadRequest("Esta vacío esa wea");
            }
            if (_servicio.GuardarArticulo(oArticulo))
            {
                return Ok("Se agrego un articulo");
            }
            else
                return StatusCode(500, "Error no se agrego");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Articulo articulo)
        {
            if (articulo == null || articulo.Id != id)
            {
                return BadRequest("No se ingresó correctamente el objeto");
            }

            //var existingArticulo = _servicio.ObtenerArticulo(id);
            //if (existingArticulo == null)
            //{
            //    return NotFound();
            //}

            var result = _servicio.GuardarArticulo(articulo);
            return Ok(result);
        }





        }
}
