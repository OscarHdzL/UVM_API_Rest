using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Catálogo de ponderaciones.
/// </summary>
public partial class Ponderacion
{
    /// <summary>
    /// Clave única de la ponderación. 
    /// </summary>
    public int PonderacionId { get; set; }

    public string NivelModalidadId { get; set; } = null!;

    public string ComponenteId { get; set; } = null!;

    public double Puntuacion { get; set; }

    /// <summary>
    /// Indica si el registro se encuentra activo en el sistema.
    /// </summary>
    public bool Activo { get; set; }

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

    public virtual Componente Componente { get; set; } = null!;

    public virtual NivelModalidad NivelModalidad { get; set; } = null!;
}
