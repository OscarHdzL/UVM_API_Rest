using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class SubIndicadorUvm
{
    /// <summary>
    /// Clave única del subindicador uvm.
    /// </summary>
    public int SubIndicadorUvmId { get; set; }

    /// <summary>
    /// Nombre del subindicador uvm.
    /// </summary>
    public string NombreSubIndicadorUvm { get; set; } = null!;

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
