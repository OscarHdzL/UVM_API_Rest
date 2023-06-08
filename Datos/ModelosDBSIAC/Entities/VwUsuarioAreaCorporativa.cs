using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwUsuarioAreaCorporativa
{
    public int IdUsuario { get; set; }

    public int IdAreaCorporativa { get; set; }

    public string? AreaCorporativa { get; set; }
}
