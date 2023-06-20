using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwCatPeriodoEvaluacion
{
    public int IdPeriodoEvaluacion { get; set; }

    public int Anio { get; set; }

    public int IdCiclo { get; set; }

    public int IdInstitucion { get; set; }

    public string Institucion { get; set; } = null!;

    public string Proceso { get; set; } = null!;

    public int IdRelEtapaPeriodoEvaluacion { get; set; }

    public int IdEtapa { get; set; }

    public string Etapa { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
