using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class IndicadorSiac
{
    /// <summary>
    /// Clave del indicador siac
    /// </summary>
    public string IndicadorSiacId { get; set; } = null!;

    /// <summary>
    /// Nombre del indicador siac
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Descripción del indicador siac
    /// </summary>
    public string Descripcion { get; set; } = null!;

    /// <summary>
    /// Estatus del indicador
    /// </summary>
    public bool Activo { get; set; }

    /// <summary>
    /// Fecha de creación del indicador
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Usuario que creo el indicador siac
    /// </summary>
    public string UsuarioCreacion { get; set; } = null!;

    /// <summary>
    /// Fecha de modificación del indicador siac
    /// </summary>
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Usuario que modifico del indicador siac
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<ConfiguracionIndicadorSiac> ConfiguracionIndicadorSiacs { get; set; } = new List<ConfiguracionIndicadorSiac>();
}
