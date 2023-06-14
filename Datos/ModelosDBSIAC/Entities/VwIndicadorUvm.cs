using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwIndicadorUvm
{
    public int Id { get; set; }

    public int ComponenteUvmId { get; set; }

    public string? NombreComponenteUvm { get; set; }

    public string? DescripcionComponenteUvm { get; set; }

    public string NombreIndicadorUvm { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
