using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwAreaCorporativaSubarea
{
    public int Id { get; set; }

    public int CatAreaCorporativaId { get; set; }

    public int CatSubAreaCorporativaId { get; set; }

    public string AreaCorporativa { get; set; } = null!;

    public string Subarea { get; set; } = null!;
}
