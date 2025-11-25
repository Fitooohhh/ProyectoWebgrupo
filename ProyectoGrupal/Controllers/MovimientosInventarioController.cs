using Microsoft.AspNetCore.Mvc;
using ProyectoGrupal.Models;

namespace ProyectoGrupal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosInventarioController : ControllerBase
    {
        private static List<MovimientoInventario> movimientos = new();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<MovimientoInventario>> Get() => movimientos;

        [HttpGet("{id}")]
        public ActionResult<MovimientoInventario> Get(int id)
        {
            var movimiento = movimientos.FirstOrDefault(m => m.Id == id);
            return movimiento == null ? NotFound() : Ok(movimiento);
        }

        [HttpPost]
        public ActionResult<MovimientoInventario> Post(MovimientoInventario movimiento)
        {
            movimiento.Id = nextId++;
            movimiento.Fecha = DateTime.UtcNow;
            movimientos.Add(movimiento);
            return CreatedAtAction(nameof(Get), new { id = movimiento.Id }, movimiento);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movimiento = movimientos.FirstOrDefault(m => m.Id == id);
            if (movimiento == null) return NotFound();
            movimientos.Remove(movimiento);
            return NoContent();
        }
    }
}