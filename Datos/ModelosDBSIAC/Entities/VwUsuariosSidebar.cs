using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwUsuariosSidebar
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public bool Activo { get; set; }

    public int CatNivelRevisionId { get; set; }

    public string? NivelRevision { get; set; }

    public int IdPerfil { get; set; }

    public string? Perfil { get; set; }

    public bool? Todos { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int? IdVista { get; set; }

    public string? Vista { get; set; }

    public int? IdTipoVista { get; set; }

    public string? TipoVista { get; set; }

    public int? IdTipoAcceso { get; set; }

    public string? TipoAcceso { get; set; }
}
