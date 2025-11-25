using Microsoft.AspNetCore.Mvc;
using ProyectoGrupal.Models;

namespace ProyectoGrupal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesCompraController : ControllerBase
    {
        private static List<OrdenCompra> ordenes = new();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<OrdenCompra>> Get() => ordenes;

        [HttpGet("{id}")]
        public ActionResult<OrdenCompra> Get(int id)
        {
            var orden = ordenes.FirstOrDefault(o => o.Id == id);
            return orden == null ? NotFound() : Ok(orden);
        }

        [HttpPost]
        public ActionResult<OrdenCompra> Post(OrdenCompra orden)
        {
            orden.Id = nextId++;
            orden.Fecha = DateTime.UtcNow;
            ordenes.Add(orden);
            return CreatedAtAction(nameof(Get), new { id = orden.Id }, orden);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var orden = ordenes.FirstOrDefault(o => o.Id == id);
            if (orden == null) return NotFound();
            ordenes.Remove(orden);
            return NoContent();
        }
    }
}