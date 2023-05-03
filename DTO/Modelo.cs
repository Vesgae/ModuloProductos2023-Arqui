namespace ModuloProductos_v1.DTO
{
    public class Modelo
    {
        public int? id { get; set; }=0;
        public int? idMarca { get; set; }=0;
        public int? idTipoVehiculo { get; set; }=0;
        public int? idTipoCombustible { get; set; }=0;
        public string? modelo{ get; set; } = "";
        public string? tipoCombustible { get; set; } = "";
        public string? tipoVehiculo { get; set; } = "";
        public string? marca { get; set; } = "";
    }
}
