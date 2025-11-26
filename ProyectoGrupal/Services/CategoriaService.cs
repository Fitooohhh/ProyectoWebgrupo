using ProyectoGrupal.Models;

namespace ProyectoGrupal.Services
{
    public class CategoriaService
    {
        private readonly List<Categoria> categorias = new();
        private int nextId = 1;

        public IEnumerable<Categoria> GetAll() => categorias;
        public Categoria? GetById(int id) => categorias.FirstOrDefault(c => c.Id == id);
        public Categoria Add(Categoria categoria)
        {
            categoria.Id = nextId++;
            categorias.Add(categoria);
            return categoria;
        }
        public bool Update(int id, Categoria categoria)
        {
            var existing = GetById(id);
            if (existing == null) return false;
            existing.Nombre = categoria.Nombre;
            return true;
        }
        public bool Delete(int id)
        {
            var categoria = GetById(id);
            if (categoria == null) return false;
            categorias.Remove(categoria);
            return true;
        }
    }
}