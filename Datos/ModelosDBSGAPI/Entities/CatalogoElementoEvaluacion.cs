using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class CatalogoElementoEvaluacion
{
    /// <summary>
    /// Clave del elemento de evaluacion
    /// </summary>
    public string ElementoEvaluacionId { get; set; } = null!;

    /// <summary>
    /// Nombre del elemento de evaluacion
    /// </summary>
    public string NombreElementoEvaluacion { get; set; } = null!;

    /// <summary>
    /// Nombre de la Evidencia
    /// </summary>
    public string NombreEvidencia { get; set; } = null!;

    /// <summary>
    /// Descripción detallada de la evidencia
    /// </summary>
    public string DescripcionEvidencia { get; set; } = null!;

    /// <summary>
    ///  Es un valor numérico entero de 3 posiciones
    /// </summary>
    public int CantidadEvidencia { get; set; }

    /// <summary>
    /// Muestra el estatus del registro
    /// </summary>
    public bool Activo { get; set; }

    /// <summary>
    /// Fecha que se creo el registro
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Usuario que creo el registro
    /// </summary>
    public string UsuarioCreacion { get; set; } = null!;

    /// <summary>
    /// Usuario que  modifico el registro
    /// </summary>
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Usuario que modifico el registro
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<ElementoEvaluacion> ElementoEvaluacions { get; set; } = new List<ElementoEvaluacion>();
}
