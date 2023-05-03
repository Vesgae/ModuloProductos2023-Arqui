using System.Collections.Generic;

namespace ModuloProductos_v1.DTO
{
    public class VehiculoEnVenta
    {
        public int? id { get; set; }=0;
        public int? idProducto { get; set; }=0;
        public int? idVehiculo { get; set; }=0;
        public string? urlFoto { get; set; } = "";
        public string? color { get; set; } = "";
        public string? placa { get; set; } = "";
        public double? precio { get; set; }=0;
        public Modelo? modelo { get; set; } = new Modelo();
        public List<Disponibilidad>? disponibilidad {get; set;} = new List<Disponibilidad>();
    }
}
