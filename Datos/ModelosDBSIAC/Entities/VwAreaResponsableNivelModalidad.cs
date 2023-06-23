using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwAreaResponsableNivelModalidad
{
    public int Id { get; set; }

    public int CatAreaResponsableId { get; set; }

    public string AreaResponsable { get; set; } = null!;

    public int CatNivelModalidadId { get; set; }

    public string NivelModalidad { get; set; } = null!;
}
