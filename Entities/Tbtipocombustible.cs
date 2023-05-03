using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbtipocombustible")]
[Index("TipoCombustible", Name = "UK_tipoCombustible", IsUnique = true)]
public partial class Tbtipocombustible
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("tipoCombustible")]
    [StringLength(32)]
    public string TipoCombustible { get; set; } = null!;

}
