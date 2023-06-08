using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Elementos de evaluación 
/// </summary>
public partial class ElementoEvaluacion
{
    /// <summary>
    /// Clave única del elemento de evaluación. 
    /// </summary>
    public int ElementoEvaluacionId { get; set; }

    /// <summary>
    /// Año al que perteneece el elemento de evaluación
    /// </summary>
    public int Anio { get; set; }

    /// <summary>
    /// Identificador del Ciclo para esta configuración.
    /// </summary>
    public string CicloId { get; set; } = null!;

    /// <summary>
    /// Clave del área responsable
    /// </summary>
    public int AreaResponsableId { get; set; }

    /// <summary>
    /// Clave del registro nivel modalidad
    /// </summary>
    public string NivelModalidadId { get; set; } = null!;

    /// <summary>
    /// Identificador del Componente que pertenece al elemento de evaluación.
    /// </summary>
    public string ComponenteId { get; set; } = null!;

    /// <summary>
    /// Identificador del Área corporativa a la que pertenece el elemento de evaluación.
    /// </summary>
    public string AreaCorporativaId { get; set; } = null!;

    /// <summary>
    /// Clave del catalogo de elemento de evaluacion
    /// </summary>
    public string ElementoEvaluacionCatalogoId { get; set; } = null!;

    /// <summary>
    /// Tipo de area si es generica es verdadero
    /// </summary>
    public bool? Generica { get; set; }

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

    public virtual AreaCorporativa AreaCorporativa { get; set; } = null!;

    public virtual AreaResponsable AreaResponsable { get; set; } = null!;

    public virtual Ciclo Ciclo { get; set; } = null!;

    public virtual Componente Componente { get; set; } = null!;

    public virtual CatalogoElementoEvaluacion ElementoEvaluacionCatalogo { get; set; } = null!;

    public virtual ICollection<EscalaMedicion> EscalaMedicions { get; set; } = new List<EscalaMedicion>();

    public virtual NivelModalidad NivelModalidad { get; set; } = null!;

    public virtual ICollection<RegistroElementoEvaluacionArchivo> RegistroElementoEvaluacionArchivos { get; set; } = new List<RegistroElementoEvaluacionArchivo>();

    public virtual ICollection<Normativa> Normativas { get; set; } = new List<Normativa>();
}
