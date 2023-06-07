using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class TblPerfil
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<CatUsuario> CatUsuarios { get; set; } = new List<CatUsuario>();

    public virtual ICollection<RelPerfilvistum> RelPerfilvista { get; set; } = new List<RelPerfilvistum>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
