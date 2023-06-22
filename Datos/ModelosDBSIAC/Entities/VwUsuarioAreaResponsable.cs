using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwUsuarioAreaResponsable
{
    public int IdUsuario { get; set; }

    public int IdAreaResponsable { get; set; }

    public string? AreaResponsable { get; set; }

    public int? IdDependenciaArea { get; set; }

    public string? DependenciaArea { get; set; }
}
