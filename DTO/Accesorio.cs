namespace ModuloProductos_v1.DTO
{
    public class Accesorio
    {
        public int? id { get; set; } = 0;
        public int? idProducto { get; set; } = 0;
        public int? idAccesorio { get; set; } = 0;
        public int? idProveedor { get; set; } = 0;
        public string? nombre { get; set; } = "";
        public string? nombreProveedor { get; set; } = "";
        public string? urlFoto { get; set; } = "";
        public double? precio { get; set; } = 0;
        public int? unidadesDisponibles { get; set; } = 0;
        public int? idSucursal { get; set; } = 0;
        public string? nombreSucursal { get; set; } = "";
        public List<Disponibilidad>? disponibilidad { get; set; } = new List<Disponibilidad>();
    }
}
