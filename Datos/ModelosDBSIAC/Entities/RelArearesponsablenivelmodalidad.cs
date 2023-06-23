using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelArearesponsablenivelmodalidad
{
    public int Id { get; set; }

    public int CatAreaResponsableId { get; set; }

    public int CatNivelModalidadId { get; set; }

    public virtual CatAreaResponsable CatAreaResponsable { get; set; } = null!;

    public virtual CatNivelModalidad CatNivelModalidad { get; set; } = null!;
}
