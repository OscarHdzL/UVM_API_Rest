using System;
using System.Collections.Generic;
namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de Criterios por Proceso
/// </summary>
public class CriterioDTO
{
    /// <summary>
    /// Identificador del proceso al que pertenece este criterio.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Número del criterio dentro del proceso.
    /// </summary>
    public string CriterioId { get; set; } = null!;

    /// <summary>
    /// Identificador de la carrera a la que se asocia este criterio. Null significa que no aplica.
    /// </summary>
    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Identificador del cápitulo al que se asocia este criterio.
    /// </summary>
    public string CapituloId { get; set; } = null!;

    /// <summary>
    /// Identificador del tipo de evidencia que se usará para este criterio.
    /// </summary>
    public string TipoEvidenciaId { get; set; } = null!;

    /// <summary>
    /// Descripción larga del criterio.
    /// </summary>
    public string Descripcion { get; set; } = null!;

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


}
