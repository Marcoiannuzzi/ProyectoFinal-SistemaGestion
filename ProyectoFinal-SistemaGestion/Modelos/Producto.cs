namespace ProyectoFinal_SistemaGestion.Models
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripciones { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }
    }
}
