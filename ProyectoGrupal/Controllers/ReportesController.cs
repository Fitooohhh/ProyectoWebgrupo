using Microsoft.AspNetCore.Mvc;
using ProyectoGrupal.Models;
using ProyectoGrupal.DTOs;
using ProyectoGrupal.Services;

namespace ProyectoGrupal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private static readonly ReporteService reporteService = new();

        [HttpGet("Stock")]
        public ActionResult<IEnumerable<ReporteStockDto>> GetStock()
        {
            return Ok(reporteService.GetStockReport(ProductosController.productos));
        }

        [HttpGet("Stock/{id}")]
        public ActionResult<ReporteStockDto> GetStockById(int id)
        {
            var reporte = reporteService.GetStockReportById(ProductosController.productos, id);
            if (reporte == null) return NotFound();
            return Ok(reporte);
        }
    }
}
