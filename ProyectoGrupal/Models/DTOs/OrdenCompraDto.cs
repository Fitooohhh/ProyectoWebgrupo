using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupal.DTOs
{
    public class OrdenCompraDto
    {
        public int Id { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [MinLength(1)]
        public List<DetalleOrdenCompraDto> Detalles { get; set; } = new();
    }

    public class DetalleOrdenCompraDto
    {
        [Required]
        public int ProductoId { get; set; }

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }
    }
}