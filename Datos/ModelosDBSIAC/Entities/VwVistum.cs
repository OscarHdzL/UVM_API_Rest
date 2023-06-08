using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwVistum
{
    public int IdVista { get; set; }

    public string Nombre { get; set; } = null!;

    public string? TipoVista { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int IdTipoVista { get; set; }
}
