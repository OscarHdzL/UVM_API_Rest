using System;
using System.Collections.Generic;
namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de Criterios por Proceso
/// </summary>
public class CarreraDTO
{
    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Nombre descriptivo de la carrera.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Plan de la carrera.
    /// </summary>
    public string Plan { get; set; } = null!;

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

    public string? UsuarioModificacion { get; set; }
}
