using ProyectoGrupal.Models;

namespace ProyectoGrupal.Services
{
    public class ProveedorService
    {
        private readonly List<Proveedor> proveedores = new();
        private int nextId = 1;

        public IEnumerable<Proveedor> GetAll() => proveedores;
        public Proveedor? GetById(int id) => proveedores.FirstOrDefault(p => p.Id == id);
        public Proveedor Add(Proveedor proveedor)
        {
            proveedor.Id = nextId++;
            proveedores.Add(proveedor);
            return proveedor;
        }
        public bool Update(int id, Proveedor proveedor)
        {
            var existing = GetById(id);
            if (existing == null) return false;
            existing.Nombre = proveedor.Nombre;
            existing.Contacto = proveedor.Contacto;
            return true;
        }
        public bool Delete(int id)
        {
            var proveedor = GetById(id);
            if (proveedor == null) return false;
            proveedores.Remove(proveedor);
            return true;
        }
    }
}