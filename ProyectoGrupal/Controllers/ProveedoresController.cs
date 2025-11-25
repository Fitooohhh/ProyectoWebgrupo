using Microsoft.AspNetCore.Mvc;
using ProyectoGrupal.Models;

namespace ProyectoGrupal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private static List<Proveedor> proveedores = new();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> Get() => proveedores;

        [HttpGet("{id}")]
        public ActionResult<Proveedor> Get(int id)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Id == id);
            return proveedor == null ? NotFound() : Ok(proveedor);
        }

        [HttpPost]
        public ActionResult<Proveedor> Post(Proveedor proveedor)
        {
            proveedor.Id = nextId++;
            proveedores.Add(proveedor);
            return CreatedAtAction(nameof(Get), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Proveedor proveedor)
        {
            var existing = proveedores.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = proveedor.Nombre;
            existing.Contacto = proveedor.Contacto;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor == null) return NotFound();
            proveedores.Remove(proveedor);
            return NoContent();
        }
    }
}