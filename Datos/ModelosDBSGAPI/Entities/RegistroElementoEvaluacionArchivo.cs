using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de archivos registrados acorde a un elemento de evaluación.
/// </summary>
public partial class RegistroElementoEvaluacionArchivo
{
    /// <summary>
    /// Identificador único del archivo registrado.
    /// </summary>
    public int RegistroElementoEvaluacionArchivoId { get; set; }

    /// <summary>
    /// Elemento de evaluación al que pertence este archivo.
    /// </summary>
    public int ElementoEvaluacionId { get; set; }

    /// <summary>
    /// Configuración general que pertenece al elemento de evaluación.
    /// </summary>
    public int ConfiguracionGeneralId { get; set; }

    public int Anio { get; set; }

    /// <summary>
    /// Identificador del Ciclo para esta configuración.
    /// </summary>
    public string CicloId { get; set; } = null!;

    /// <summary>
    /// Nombre físico del archivo.
    /// </summary>
    public string NombreArchivo { get; set; } = null!;

    /// <summary>
    /// El mime type del tipo de archivo.
    /// </summary>
    public string Mime { get; set; } = null!;

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

    public virtual Ciclo Ciclo { get; set; } = null!;

    public virtual ElementoEvaluacion ElementoEvaluacion { get; set; } = null!;
}
