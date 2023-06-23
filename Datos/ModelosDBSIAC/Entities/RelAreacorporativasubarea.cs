using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelAreacorporativasubarea
{
    public int Id { get; set; }

    public int CatAreaCorporativaId { get; set; }

    public string Subarea { get; set; } = null!;

    public virtual CatAreaCorporativa CatAreaCorporativa { get; set; } = null!;
}
