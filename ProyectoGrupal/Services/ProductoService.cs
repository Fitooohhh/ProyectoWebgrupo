using ProyectoGrupal.Models;

namespace ProyectoGrupal.Services
{
    public class ProductoService
    {
        private readonly List<Producto> productos = new();
        private int nextId = 1;

        public IEnumerable<Producto> GetAll() => productos;
        public Producto? GetById(int id) => productos.FirstOrDefault(p => p.Id == id);
        public Producto Add(Producto producto)
        {
            producto.Id = nextId++;
            productos.Add(producto);
            return producto;
        }
        public bool Update(int id, Producto producto)
        {
            var existing = GetById(id);
            if (existing == null) return false;
            existing.Nombre = producto.Nombre;
            existing.Descripcion = producto.Descripcion;
            existing.CategoriaId = producto.CategoriaId;
            existing.Stock = producto.Stock;
            existing.ProveedorId = producto.ProveedorId;
            return true;
        }
        public bool Delete(int id)
        {
            var producto = GetById(id);
            if (producto == null) return false;
            productos.Remove(producto);
            return true;
        }
    }
}