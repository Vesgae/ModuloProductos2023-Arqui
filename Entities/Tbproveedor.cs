using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbproveedor")]
public partial class Tbproveedor
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(32)]
    public string Nombre { get; set; } = null!;
}
