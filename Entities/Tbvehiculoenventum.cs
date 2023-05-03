using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbvehiculoenventa")]
[Index("IdProducto", Name = "FK_Producto_VehiculoEnVenta")]
[Index("IdVehiculo", Name = "FK_Vehiculo_VehiculoEnVenta")]
public partial class Tbvehiculoenventum
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }
    [ForeignKey("IdVehiculo")]
    [Column("idVehiculo", TypeName = "int(11)")]
    public int IdVehiculo { get; set; }
    [ForeignKey("IdProducto")]
    [Column("idProducto", TypeName = "int(11)")]
    public int IdProducto { get; set; }
}
