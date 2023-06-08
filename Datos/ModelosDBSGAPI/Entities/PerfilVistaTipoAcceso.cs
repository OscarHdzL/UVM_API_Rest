using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Listado de tipos de acceso acorde a las pantallas del perfil
/// </summary>
public partial class PerfilVistaTipoAcceso
{
    /// <summary>
    /// Identificador único de la relacion de perfil/vista y tipo acceso.
    /// </summary>
    public int PerfilVistaTipoAccesoId { get; set; }

    /// <summary>
    /// Identificador de la vistas acorde al perfil.
    /// </summary>
    public int PerfilVistaId { get; set; }

    /// <summary>
    /// Identificador del tipo de acceso.
    /// </summary>
    public string TipoAccesoId { get; set; } = null!;

    public virtual PerfilVistum PerfilVista { get; set; } = null!;

    public virtual TipoAcceso TipoAcceso { get; set; } = null!;
}
