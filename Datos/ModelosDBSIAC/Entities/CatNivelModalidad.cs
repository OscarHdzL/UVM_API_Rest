using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

/// <summary>
/// Listado de Nivel/Modalidad
/// </summary>
public partial class CatNivelModalidad
{
    /// <summary>
    /// Siglas de identificación única para la Nivel/Modalidad.
    /// </summary>
    public int Id { get; set; }

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

    public string Clave { get; set; } = null!;

    public virtual ICollection<CatPonderacion> CatPonderacions { get; set; } = new List<CatPonderacion>();

    public virtual ICollection<RelArearesponsablenivelmodalidad> RelArearesponsablenivelmodalidads { get; set; } = new List<RelArearesponsablenivelmodalidad>();

    public virtual ICollection<RelCampusnivelmodalidad> RelCampusnivelmodalidads { get; set; } = new List<RelCampusnivelmodalidad>();
}
