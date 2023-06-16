using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwVistasPerfil
{
    public int IdPerfil { get; set; }

    public string Perfil { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int IdVista { get; set; }

    public string Vista { get; set; } = null!;

    public int IdTipoVista { get; set; }

    public string TipoVista { get; set; } = null!;

    public int IdTipoAcceso { get; set; }

    public string TipoAcceso { get; set; } = null!;

    public string TipoAccesoDescripcion { get; set; } = null!;
}
