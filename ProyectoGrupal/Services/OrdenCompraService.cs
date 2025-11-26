using ProyectoGrupal.Models;

namespace ProyectoGrupal.Services
{
    public class OrdenCompraService
    {
        private readonly List<OrdenCompra> ordenes = new();
        private int nextId = 1;

        public IEnumerable<OrdenCompra> GetAll() => ordenes;
        public OrdenCompra? GetById(int id) => ordenes.FirstOrDefault(o => o.Id == id);
        public OrdenCompra Add(OrdenCompra orden)
        {
            orden.Id = nextId++;
            orden.Fecha = DateTime.UtcNow;
            ordenes.Add(orden);
            return orden;
        }
        public bool Delete(int id)
        {
            var orden = GetById(id);
            if (orden == null) return false;
            ordenes.Remove(orden);
            return true;
        }
    }
}