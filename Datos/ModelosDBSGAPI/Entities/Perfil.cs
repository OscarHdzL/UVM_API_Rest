using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Catálogo de matriz de indicadores de Perfiles.
/// </summary>
public partial class Perfil
{
    /// <summary>
    /// Clave única del perfil. 
    /// </summary>
    public int PerfilId { get; set; }

    /// <summary>
    /// Nombre del perfil.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Vista inicial del usuario al iniciar sesión.
    /// </summary>
    public string VistaInicial { get; set; } = null!;

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

    public virtual ICollection<PerfilCampus> PerfilCampuses { get; set; } = new List<PerfilCampus>();

    public virtual ICollection<PerfilVistum> PerfilVista { get; set; } = new List<PerfilVistum>();

    public virtual Vistum VistaInicialNavigation { get; set; } = null!;
}
