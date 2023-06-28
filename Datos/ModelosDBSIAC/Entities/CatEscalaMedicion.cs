using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatEscalaMedicion
{
    public int Id { get; set; }

    public string Escala { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<RelEscalamedicioncondicion> RelEscalamedicioncondicions { get; set; } = new List<RelEscalamedicioncondicion>();
}
