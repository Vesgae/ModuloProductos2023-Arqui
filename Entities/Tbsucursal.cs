using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbsucursal")]
public partial class Tbsucursal
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("ciudad")]
    [StringLength(32)]
    public string Ciudad { get; set; } = null!;

    [Column("dirección")]
    [StringLength(128)]
    public string Dirección { get; set; } = null!;

    [Column("nombre")]
    [StringLength(64)]
    public string Nombre { get; set; } = null!;
}
