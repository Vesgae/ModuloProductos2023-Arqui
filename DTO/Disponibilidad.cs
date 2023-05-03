namespace ModuloProductos_v1.DTO
{
    public class Disponibilidad
    {
        public int? id { get; set; }=0;
        public int? idSucursal { get; set; }=0;
        public int? disponibilidad { get; set; }=0;
        public string? nombreSucursal { get; set; } = "";
        public string? ciudadSucursal { get; set; } = "";
    }
}