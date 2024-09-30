using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Actividad01.Service;
using Actividad01.Dominio;

namespace Actividad_03.Controllers
{
    [ApiController]
    [Route("Articulo")]
    public class FacturaController : Controller
    {
        Servicio servicio;
        public FacturaController()
        {
            servicio = new Servicio();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(servicio.ObtenerFacturas());
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Post([FromBody] Factura oFactura)
        {
            if (oFactura == null)
            {
                return BadRequest("Esta vacío esa wea");
            }
            if (servicio.GuardarFactura(oFactura))
            {
                return Ok("Se agrego un articulo");
            }

            else
                return StatusCode(500, "Error no se agrego");
        }
      

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Put (int id, [FromBody] Factura oFactura)
        {
            if (oFactura == null || id != oFactura.Id)
            {
                return BadRequest("Los datos del producto no son válidos.");
            }

            // Actualizar el producto existente


            return Ok(servicio.GuardarFactura(oFactura)); // 200 OK con el recurso actualizado
        }

        [HttpDelete]
        [Route("DarBaja")]
        public IActionResult Delete (int id)
        {
            return Ok(servicio.DarBaja(id));
        }
    }
}
