using Microsoft.AspNetCore.Mvc;
using ProyectoGrupal.Models;

namespace ProyectoGrupal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        // Lista pública para permitir acceso desde otros controladores/servicios
        public static List<Producto> productos = new();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get() => productos;

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            producto.Id = nextId++;
            productos.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Producto producto)
        {
            var existing = productos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = producto.Nombre;
            existing.Descripcion = producto.Descripcion;
            existing.CategoriaId = producto.CategoriaId;
            existing.Stock = producto.Stock;
            existing.ProveedorId = producto.ProveedorId;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            productos.Remove(producto);
            return NoContent();
        }
    }
}