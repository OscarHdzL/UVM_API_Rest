using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwUsuarioNivelModalidad
{
    public int IdUsuario { get; set; }

    public int IdNivelModalidadId { get; set; }

    public string? Nivel { get; set; }

    public string? Modalidad { get; set; }
}
