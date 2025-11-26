using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupal.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public int ProveedorId { get; set; }
    }
}