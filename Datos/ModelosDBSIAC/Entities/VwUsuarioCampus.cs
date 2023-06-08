using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwUsuarioCampus
{
    public int IdUsuario { get; set; }

    public int IdCampus { get; set; }

    public string? Campus { get; set; }
}
