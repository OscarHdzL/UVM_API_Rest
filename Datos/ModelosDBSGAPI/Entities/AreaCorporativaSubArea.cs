using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Subareas de una área corporativa.
/// </summary>
public partial class AreaCorporativaSubArea
{
    /// <summary>
    /// Clave única de la sub área corporativa.
    /// </summary>
    public int AreaCorporativaSubAreaId { get; set; }

    /// <summary>
    /// Identificador de la área corporativa.
    /// </summary>
    public string AreaCorporativaId { get; set; } = null!;

    /// <summary>
    /// Nombre de la sub área corporativa 
    /// </summary>
    public string Nombre { get; set; } = null!;

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

    public virtual AreaCorporativa AreaCorporativa { get; set; } = null!;
}
