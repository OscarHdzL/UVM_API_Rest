using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class AreaResponsableNivelModalidad
{
    /// <summary>
    /// Identificador del Área responsable para el Nivel/Modalidad.
    /// </summary>
    public int AreaResponsableNivelModalidadId { get; set; }

    /// <summary>
    /// Identificador del Área responsable.
    /// </summary>
    public int AreaResponsableId { get; set; }

    /// <summary>
    /// Identificador del Nivel/Modalidad.
    /// </summary>
    public string NivelModalidadId { get; set; } = null!;

    /// <summary>
    /// Fecha en la que fue creado el registro.
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Usuario que generó el registro.
    /// </summary>
    public string UsuarioCreacion { get; set; } = null!;

    /// <summary>
    /// Fecha de última modificación del registro.
    /// </summary>
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Usuario de última modificación del registro.
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public virtual AreaResponsable AreaResponsable { get; set; } = null!;

    public virtual NivelModalidad NivelModalidad { get; set; } = null!;
}
