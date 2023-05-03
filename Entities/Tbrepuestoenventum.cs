using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbrepuestoenventa")]
[Index("IdProducto", Name = "FK_Producto_RepuestoEnVenta")]
[Index("IdRepuesto", Name = "FK_Repuesto_RepuestoEnVenta")]
public partial class Tbrepuestoenventum
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }
    [ForeignKey("IdRepuesto")]
    [Column("idRepuesto", TypeName = "int(11)")]
    public int IdRepuesto { get; set; }
    [ForeignKey("IdProducto")]
    [Column("idProducto", TypeName = "int(11)")]
    public int IdProducto { get; set; }
}
