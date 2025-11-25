namespace ProyectoGrupal.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public int Stock { get; set; }
        public int ProveedorId { get; set; }
    }
}