using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwCatCampus
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdRegion { get; set; }

    public string? Region { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string Clave { get; set; } = null!;

    public string? NivelModalidad { get; set; }
}
