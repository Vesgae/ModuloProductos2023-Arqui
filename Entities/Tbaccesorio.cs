using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbaccesorio")]
[Index("IdProveedor", Name = "FK_Proveedor_Accesorio")]
public partial class Tbaccesorio
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(64)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("IdProveedor")]
    [Column("idProveedor", TypeName = "int(11)")]
    public int IdProveedor { get; set; }
}
