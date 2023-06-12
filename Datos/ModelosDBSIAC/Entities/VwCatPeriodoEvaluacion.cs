using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwCatPeriodoEvaluacion
{
    public int Id { get; set; }

    public int AnioId { get; set; }

    public string IdCiclo { get; set; } = null!;

    public string? Ciclo { get; set; }

    public DateTime FechaInicialMeta { get; set; }

    public DateTime FechaFinMeta { get; set; }

    public DateTime FechaInicialCapturaResultados { get; set; }

    public DateTime FechaFinCapturaResultados { get; set; }

    public DateTime FechaInicialCargaEvidencia { get; set; }

    public DateTime FechaFinCargaEvidencia { get; set; }

    public DateTime FechaInicialAutoEvaluacion { get; set; }

    public DateTime FechaFinAutoEvaluacion { get; set; }

    public DateTime FechaInicialRevision { get; set; }

    public DateTime FechaFinRevision { get; set; }

    public DateTime FechaInicialPlanMejora { get; set; }

    public DateTime FechaFinPlanMejora { get; set; }

    public DateTime FechaInicialAuditoria { get; set; }

    public DateTime FechaFinAuditoria { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
