using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbvehiculo")]
[Index("IdModelo", Name = "FK_Modelo_Vehiculo")]
[Index("IdPropietario", Name = "FK_Propietario_Vehiculo")]
public partial class Tbvehiculo
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("placa")]
    [StringLength(6)]
    public string Placa { get; set; } = null!;

    [Column("color")]
    [StringLength(16)]
    public string Color { get; set; } = null!;
    [ForeignKey("IdModelo")]
    [Column("idModelo", TypeName = "int(11)")]
    public int IdModelo { get; set; }
    [ForeignKey("IdPropietario")]
    [Column("idPropietario", TypeName = "int(11)")]
    public int IdPropietario { get; set; }
}
