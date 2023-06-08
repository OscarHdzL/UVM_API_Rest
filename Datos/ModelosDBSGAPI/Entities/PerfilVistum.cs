using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Asociación entre perfil, vista y tipo de acceso.
/// </summary>
public partial class PerfilVistum
{
    /// <summary>
    /// Identificador único del tipo de acceso asociado a la vista y perfil.
    /// </summary>
    public int PerfilVistaId { get; set; }

    /// <summary>
    /// Identificador del perfil.
    /// </summary>
    public int PerfilId { get; set; }

    /// <summary>
    /// Identificador de la vista.
    /// </summary>
    public string VistaId { get; set; } = null!;

    public virtual Perfil Perfil { get; set; } = null!;

    public virtual ICollection<PerfilVistaTipoAcceso> PerfilVistaTipoAccesos { get; set; } = new List<PerfilVistaTipoAcceso>();

    public virtual Vistum Vista { get; set; } = null!;
}
