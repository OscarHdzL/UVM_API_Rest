﻿using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

/// <summary>
/// Catálogo de niveles organizacionales.
/// </summary>
public partial class NivelOrganizacional
{
    /// <summary>
    /// Clave única del nivel organizacional. 
    /// </summary>
    public string NivelOrganizacionalId { get; set; } = null!;

    /// <summary>
    /// Nombre del nivel organizacional.
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

    public virtual ICollection<AreaResponsabilidad> AreaResponsabilidads { get; set; } = new List<AreaResponsabilidad>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual ICollection<Subarea> Subareas { get; set; } = new List<Subarea>();
}
