using System.ComponentModel.DataAnnotations;

namespace ProyectoGrupal.DTOs
{
    public class ProveedorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Contacto { get; set; }
    }
}