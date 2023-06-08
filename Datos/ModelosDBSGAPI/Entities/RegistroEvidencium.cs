using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Tabla donde se generan los registros de evidencia en base los indices.
/// </summary>
public partial class RegistroEvidencium
{
    public int RegistroEvidenciaId { get; set; }

    public int AcreditadoraProcesoId { get; set; }

    public string CarreraId { get; set; } = null!;

    public string CriterioId { get; set; } = null!;

    public int EvidenciaId { get; set; }

    public string SubareaId { get; set; } = null!;

    public string CampusId { get; set; } = null!;

    public int? AnioId { get; set; }

    public string? CicloId { get; set; }

    public bool? EsCargada { get; set; }

    public bool? EsAceptada { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual AcreditadoraProceso AcreditadoraProceso { get; set; } = null!;

    public virtual Campus Campus { get; set; } = null!;

    public virtual Ciclo? Ciclo { get; set; }

    public virtual Criterio Criterio { get; set; } = null!;

    public virtual Evidencium Evidencium { get; set; } = null!;

    public virtual ICollection<RegistroEvidenciaArchivo> RegistroEvidenciaArchivos { get; set; } = new List<RegistroEvidenciaArchivo>();

    public virtual Subarea Subarea { get; set; } = null!;
}
