using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModuloProductos_v1.Entities;

[Table("tbmodelo")]
[Index("IdMarca", Name = "FK_Marca_Modelo")]
[Index("IdTipoCombustible", Name = "FK_tipoCombustible_Modelo")]
[Index("IdTipoVehiculo", Name = "FK_tipoVehiculo_Modelo")]
public partial class Tbmodelo
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("modelo")]
    [StringLength(64)]
    public string Modelo { get; set; } = null!;

    [ForeignKey("IdTipoCombustible")]
    [Column("idTipoCombustible", TypeName = "int(11)")]
    public int IdTipoCombustible { get; set; }

    [ForeignKey("IdMarca")]
    [Column("idMarca", TypeName = "int(11)")]
    public int IdMarca { get; set; }
    [ForeignKey("IdTipoVehiculo")]
    [Column("idTipoVehiculo", TypeName = "int(11)")]
    public int IdTipoVehiculo { get; set; }

}
