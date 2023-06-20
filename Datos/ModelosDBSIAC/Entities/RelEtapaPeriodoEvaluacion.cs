using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelEtapaPeriodoEvaluacion
{
    public int Id { get; set; }

    public int CatEtapaId { get; set; }

    public int CatPeriodoEvaluacionId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }
}
