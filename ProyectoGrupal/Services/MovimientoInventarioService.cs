using ProyectoGrupal.Models;

namespace ProyectoGrupal.Services
{
    public class MovimientoInventarioService
    {
        private readonly List<MovimientoInventario> movimientos = new();
        private int nextId = 1;

        public IEnumerable<MovimientoInventario> GetAll() => movimientos;
        public MovimientoInventario? GetById(int id) => movimientos.FirstOrDefault(m => m.Id == id);
        public MovimientoInventario Add(MovimientoInventario movimiento)
        {
            movimiento.Id = nextId++;
            movimiento.Fecha = DateTime.UtcNow;
            movimientos.Add(movimiento);
            return movimiento;
        }
        public bool Delete(int id)
        {
            var movimiento = GetById(id);
            if (movimiento == null) return false;
            movimientos.Remove(movimiento);
            return true;
        }
    }
}