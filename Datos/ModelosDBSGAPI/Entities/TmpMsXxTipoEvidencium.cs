using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class TmpMsXxTipoEvidencium
{
    public int AcreditadoraProcesoId { get; set; }

    public string TipoEvidenciaId { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string RegionId { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
