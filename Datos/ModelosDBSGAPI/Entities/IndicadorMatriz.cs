using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Catálogo de matriz de indicadores de UVM.
/// </summary>
public partial class IndicadorMatriz
{
    /// <summary>
    /// Clave única de la matriz e indicador UVM. 
    /// </summary>
    public int IndicadorMatrizId { get; set; }

    public string Componente { get; set; } = null!;

    public string? ComponenteDefinicion { get; set; }

    public string Indicador { get; set; } = null!;

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
}
