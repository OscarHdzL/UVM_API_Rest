using System;
using System.Collections.Generic;
namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de Criterios por Proceso
/// </summary>
public class AcreditadoraProcesoDTO
{
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador de la acreditadora a la que perteneces este proceso.
    /// </summary>
    public string AcreditadoraId { get; set; } = null!;

    /// <summary>
    /// Nombre del proceso. Usualmente es un año seguido de un ciclo.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Fecha de inicio del proceso.
    /// </summary>
    public DateTime FechaInicio { get; set; }

    /// <summary>
    /// Fecha de fin del proceso. Limite para generar y documentar evidencias.
    /// </summary>
    public DateTime FechaFin { get; set; }

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

}
