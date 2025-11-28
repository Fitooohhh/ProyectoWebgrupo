using ProyectoGrupal.Models;
using ProyectoGrupal.DTOs;

namespace ProyectoGrupal.Services
{
    // Servicio para obtener reportes de stock
    public class ReporteService
    {
        public IEnumerable<ReporteStockDto> GetStockReport(IEnumerable<Producto> productos)
        {
            // Mapea los productos al DTO de reporte de stock
            return productos.Select(p => new ReporteStockDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Stock = p.Stock
            });
        }

        public ReporteStockDto? GetStockReportById(IEnumerable<Producto> productos, int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return null;
            return new ReporteStockDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Stock = producto.Stock
            };
        }
    }
}
