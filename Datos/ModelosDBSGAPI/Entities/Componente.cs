using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Catálogo de componentes.
/// </summary>
public partial class Componente
{
    /// <summary>
    /// Clave única del componente. 
    /// </summary>
    public string ComponenteId { get; set; } = null!;

    /// <summary>
    /// Nombre del componente.
    /// </summary>
    public string Nombre { get; set; } = null!;

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

    public virtual ICollection<ConfiguracionIndicadorSiac> ConfiguracionIndicadorSiacs { get; set; } = new List<ConfiguracionIndicadorSiac>();

    public virtual ICollection<ElementoEvaluacion> ElementoEvaluacions { get; set; } = new List<ElementoEvaluacion>();

    public virtual ICollection<EscalaMedicion> EscalaMedicions { get; set; } = new List<EscalaMedicion>();

    public virtual ICollection<Ponderacion> Ponderacions { get; set; } = new List<Ponderacion>();
}
