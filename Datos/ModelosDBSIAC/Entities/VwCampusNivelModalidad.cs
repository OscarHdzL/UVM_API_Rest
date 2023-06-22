using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwCampusNivelModalidad
{
    public int Id { get; set; }

    public int CatCampusId { get; set; }

    public string Campus { get; set; } = null!;

    public int CatNivelModalidadId { get; set; }

    public string NivelModalidad { get; set; } = null!;
}
