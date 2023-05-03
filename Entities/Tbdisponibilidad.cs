using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbdisponibilidad")]
[Index("IdProducto", Name = "FK_Producto_Disponibilidad")]
[Index("IdSucursal", Name = "FK_Sucursal_Disponibilidad")]
public partial class Tbdisponibilidad
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("cantidad", TypeName = "int(11)")]
    public int Cantidad { get; set; }
    [ForeignKey("IdSucursal")]
    [Column("idSucursal", TypeName = "int(11)")]
    public int IdSucursal { get; set; }
    [ForeignKey("IdProducto")]
    [Column("idProducto", TypeName = "int(11)")]
    public int IdProducto { get; set; }
}
