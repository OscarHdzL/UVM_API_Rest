using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de Nivel/Modalidad
/// </summary>
public partial class NivelModalidad
{
    /// <summary>
    /// Siglas de identificación única para la Nivel/Modalidad.
    /// </summary>
    public string NivelModalidadId { get; set; } = null!;

    /// <summary>
    /// Nivel  de Nivel/Modalidad.
    /// </summary>
    public string Nivel { get; set; } = null!;

    /// <summary>
    /// Modalidad de Nivel/Modalidad.
    /// </summary>
    public string Modalidad { get; set; } = null!;

    /// <summary>
    /// Indicador de activo/inactivo para el registro.
    /// </summary>
    public bool Activo { get; set; }

    /// <summary>
    /// Fecha de creación del registro.
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
    /// Usuario que realizó la última modificación sobre el registro.
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<AreaResponsableNivelModalidad> AreaResponsableNivelModalidads { get; set; } = new List<AreaResponsableNivelModalidad>();

    public virtual ICollection<ConfiguracionGeneral> ConfiguracionGenerals { get; set; } = new List<ConfiguracionGeneral>();

    public virtual ICollection<ConfiguracionIndicadorSiac> ConfiguracionIndicadorSiacs { get; set; } = new List<ConfiguracionIndicadorSiac>();

    public virtual ICollection<ElementoEvaluacion> ElementoEvaluacions { get; set; } = new List<ElementoEvaluacion>();

    public virtual ICollection<EscalaMedicion> EscalaMedicions { get; set; } = new List<EscalaMedicion>();

    public virtual ICollection<Ponderacion> Ponderacions { get; set; } = new List<Ponderacion>();

    public virtual ICollection<Campus> Campuses { get; set; } = new List<Campus>();
}
