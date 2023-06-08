using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwUsuarioRegion
{
    public int IdUsuario { get; set; }

    public string Usuario { get; set; } = null!;

    public int IdRegion { get; set; }

    public string? Region { get; set; }
}
