namespace ModuloProductos_v1.DTO
{
    public class Repuesto
    {
        public int? id { get; set; } = 0;
        public int? idProducto { get; set; } = 0;
        public int? idRepuesto { get; set; } = 0;
        public string? nombre { get; set; } = "";
        public string? urlFoto { get; set; } = "";
        public double? precio { get; set; } = 0;
        public int? unidadesDisponibles { get; set; } = 0;
        public int? idSucursal { get; set; } = 0;
        public string? nombreSucursal { get; set; } = "";
        public int? idModelo { get; set; } = 0;
        public int? idMarca { get; set; } = 0;
        public string? modelo { get; set; } = "";
        public string? marca { get; set; } = "";
        public List<Disponibilidad>? disponibilidad { get; set; } = new List<Disponibilidad>();
    }
}
