using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbtipovehiculo")]
[Index("TipoVehiculo", Name = "UK_tipoVehiculo", IsUnique = true)]
public partial class Tbtipovehiculo
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("tipoVehiculo")]
    [StringLength(32)]
    public string TipoVehiculo { get; set; } = null!;

}
