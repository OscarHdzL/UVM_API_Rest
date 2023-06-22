using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelCampusnivelmodalidad
{
    public int Id { get; set; }

    public int CatCampusId { get; set; }

    public int CatNivelModalidadId { get; set; }

    public virtual CatCampus CatCampus { get; set; } = null!;

    public virtual CatNivelModalidad CatNivelModalidad { get; set; } = null!;
}
