using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupal.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; }
    }
}