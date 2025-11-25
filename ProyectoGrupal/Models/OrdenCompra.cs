namespace ProyectoGrupal.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleOrdenCompra> Detalles { get; set; } = new();
    }

    public class DetalleOrdenCompra
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}