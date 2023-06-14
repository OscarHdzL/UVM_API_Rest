using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwComponenteUvm
{
    public int Id { get; set; }

    public string NombreComponenteUvm { get; set; } = null!;

    public string DescripcionComponenteUvm { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
