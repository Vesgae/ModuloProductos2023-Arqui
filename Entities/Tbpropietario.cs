using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbpropietario")]
[Index("NumeroDocumento", Name = "UK_numeroDocumento", IsUnique = true)]
public partial class Tbpropietario
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("numeroDocumento", TypeName = "int(11)")]
    public int NumeroDocumento { get; set; }

    [Column("nombres")]
    [StringLength(32)]
    public string Nombres { get; set; } = null!;

    [Column("apellido")]
    [StringLength(32)]
    public string Apellido { get; set; } = null!;

    [Column("telefono")]
    [StringLength(32)]
    public string Telefono { get; set; } = null!;

    [Column("fechaNacimiento", TypeName = "date")]
    [NotMapped]
    public DateOnly FechaNacimiento { get; set; }

    [Column("correo")]
    [StringLength(32)]
    public string Correo { get; set; } = null!;
}
