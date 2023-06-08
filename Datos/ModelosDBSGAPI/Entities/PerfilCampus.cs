using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Asociación entre perfil y campuses del sistema.
/// </summary>
public partial class PerfilCampus
{
    /// <summary>
    /// Clave única de la asociación perfil y campus.
    /// </summary>
    public int PerfilCampusId { get; set; }

    /// <summary>
    /// Identificador del perfil.
    /// </summary>
    public int PerfilId { get; set; }

    /// <summary>
    /// Identificador del campus
    /// </summary>
    public string CampusId { get; set; } = null!;

    public virtual Campus Campus { get; set; } = null!;

    public virtual Perfil Perfil { get; set; } = null!;
}
