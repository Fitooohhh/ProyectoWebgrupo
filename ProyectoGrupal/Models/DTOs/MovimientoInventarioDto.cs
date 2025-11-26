using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupal.DTOs
{
    public class MovimientoInventarioDto
    {
        public int Id { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [RegularExpression("^(Entrada|Salida)$", ErrorMessage = "Tipo debe ser 'Entrada' o 'Salida'")]
        public string Tipo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}