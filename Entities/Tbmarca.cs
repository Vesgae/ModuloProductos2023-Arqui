using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbmarca")]
[Index("Marca", Name = "UK_marca", IsUnique = true)]
public partial class Tbmarca
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("marca")]
    [StringLength(32)]
    public string Marca { get; set; } = null!;
}
