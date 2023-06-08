using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Configuración general para SIAC
/// </summary>
public partial class ConfiguracionGeneral
{
    public int Anio { get; set; }

    /// <summary>
    /// Identificador del Ciclo para esta configuración.
    /// </summary>
    public string CicloId { get; set; } = null!;

    /// <summary>
    /// Clave única de la configuración general para SIAC
    /// </summary>
    public int ConfiguracionGeneralId { get; set; }

    public bool? Generica { get; set; }

    /// <summary>
    /// Identificador del Nivel/Modalidad para esta configuración.
    /// </summary>
    public string NivelModalidadId { get; set; } = null!;

    /// <summary>
    /// Identificador del Área responsable para esta configuración.
    /// </summary>
    public int AreaResponsableId { get; set; }

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

    public virtual AreaResponsable AreaResponsable { get; set; } = null!;

    public virtual Ciclo Ciclo { get; set; } = null!;

    public virtual NivelModalidad NivelModalidad { get; set; } = null!;
}
