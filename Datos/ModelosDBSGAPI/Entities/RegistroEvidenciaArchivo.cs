using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de archivos registrados como evidencia.
/// </summary>
public partial class RegistroEvidenciaArchivo
{
    public int RegistroEvidenciaArchivoId { get; set; }

    public int RegistroEvidenciaId { get; set; }

    public int AcreditadoraProcesoId { get; set; }

    public string CarreraId { get; set; } = null!;

    public string CriterioId { get; set; } = null!;

    public int EvidenciaId { get; set; }

    public string SubareaId { get; set; } = null!;

    public string CampusId { get; set; } = null!;

    public bool EsUrl { get; set; }

    public string? NombreArchivo { get; set; }

    public string? Mime { get; set; }

    public string? Url { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual RegistroEvidencium RegistroEvidencium { get; set; } = null!;
}
