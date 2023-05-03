using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbaccesorioenventa")]
[Index("IdAccesorio", Name = "FK_Accesorio_AccesorioEnVenta")]
[Index("IdProducto", Name = "FK_Producto_AccesorioEnVenta")]
public partial class Tbaccesorioenventum
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [ForeignKey("IdAccesorio")]
    [Column("idAccesorio", TypeName = "int(11)")]
    public int IdAccesorio { get; set; }
    [ForeignKey("IdProducto")]
    [Column("idProducto", TypeName = "int(11)")]
    public int IdProducto { get; set; }
}
