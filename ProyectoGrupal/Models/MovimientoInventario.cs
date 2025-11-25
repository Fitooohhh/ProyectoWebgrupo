namespace ProyectoGrupal.Models
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}