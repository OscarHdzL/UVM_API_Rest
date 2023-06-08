using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Catálogo de áreas responsables.
/// </summary>
public partial class AreaResponsable
{
    /// <summary>
    /// Clave única del Área responsable.
    /// </summary>
    public int AreaResponsableId { get; set; }

    /// <summary>
    /// Nombre del área responsable
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Identificador del Área responsable padre al que pertenece este Área responsable.
    /// </summary>
    public int? AreaResponsablePadre { get; set; }

    /// <summary>
    /// Indica si el Área responsable es genérica.
    /// </summary>
    public bool Generica { get; set; }

    /// <summary>
    /// Indica si la información se va a consolidar los resultados de la etapa de Autoevaluación.
    /// </summary>
    public bool Consolidacion { get; set; }

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

    public virtual ICollection<AreaResponsableNivelModalidad> AreaResponsableNivelModalidads { get; set; } = new List<AreaResponsableNivelModalidad>();

    public virtual AreaResponsable? AreaResponsablePadreNavigation { get; set; }

    public virtual ICollection<ConfiguracionGeneral> ConfiguracionGenerals { get; set; } = new List<ConfiguracionGeneral>();

    public virtual ICollection<ConfiguracionIndicadorSiac> ConfiguracionIndicadorSiacs { get; set; } = new List<ConfiguracionIndicadorSiac>();

    public virtual ICollection<ElementoEvaluacion> ElementoEvaluacions { get; set; } = new List<ElementoEvaluacion>();

    public virtual ICollection<EscalaMedicion> EscalaMedicions { get; set; } = new List<EscalaMedicion>();

    public virtual ICollection<AreaResponsable> InverseAreaResponsablePadreNavigation { get; set; } = new List<AreaResponsable>();
}
