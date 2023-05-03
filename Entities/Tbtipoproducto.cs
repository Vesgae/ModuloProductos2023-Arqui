using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbtipoproducto")]
[Index("TipoProducto", Name = "UK_tipoProducto", IsUnique = true)]
public partial class Tbtipoproducto
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("tipoProducto")]
    [StringLength(16)]
    public string TipoProducto { get; set; } = null!;
}
