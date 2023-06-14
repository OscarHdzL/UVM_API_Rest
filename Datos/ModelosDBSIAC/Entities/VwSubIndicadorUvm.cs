using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwSubIndicadorUvm
{
    public int Id { get; set; }

    public string NombreSubIndicadorUvm { get; set; } = null!;

    public int IndicadorUvmId { get; set; }

    public string? NombreIndicadorUvm { get; set; }

    public int? ComponenteUvmId { get; set; }

    public string? NombreComponenteUvm { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
