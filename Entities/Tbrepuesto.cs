using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbrepuesto")]
[Index("IdModelo", Name = "FK_Modelo_Repuesto")]
public partial class Tbrepuesto
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(64)]
    public string Nombre { get; set; } = null!;
    [ForeignKey("IdModelo")]
    [Column("idModelo", TypeName = "int(11)")]
    public int IdModelo { get; set; }

}
