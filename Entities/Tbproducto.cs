using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbproducto")]
[Index("IdTipoProducto", Name = "FK_tipoProducto_Producto")]
public partial class Tbproducto
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("precioUnitario")]
    [Precision(12, 2)]
    public decimal PrecioUnitario { get; set; }

    [Column("urlFotografia")]
    [StringLength(128)]
    public string UrlFotografia { get; set; } = null!;
    [ForeignKey("IdTipoProducto")]
    [Column("idTipoProducto", TypeName = "int(11)")]
    public int IdTipoProducto { get; set; }
}
