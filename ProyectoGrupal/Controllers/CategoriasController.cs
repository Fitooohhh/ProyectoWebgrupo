using Microsoft.AspNetCore.Mvc;
using ProyectoGrupal.Models;

namespace ProyectoGrupal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private static List<Categoria> categorias = new();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get() => categorias;

        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            return categoria == null ? NotFound() : Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            categoria.Id = nextId++;
            categorias.Add(categoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Categoria categoria)
        {
            var existing = categorias.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = categoria.Nombre;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null) return NotFound();
            categorias.Remove(categoria);
            return NoContent();
        }
    }
}