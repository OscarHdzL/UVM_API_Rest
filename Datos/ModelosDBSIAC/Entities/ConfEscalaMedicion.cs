using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class ConfEscalaMedicion
{
    public int Id { get; set; }

    public int ConfIndicadorSiacId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ConfIndicadorSiac ConfIndicadorSiac { get; set; } = null!;

    public virtual ICollection<RelEscalamedicioncondicion> RelEscalamedicioncondicions { get; set; } = new List<RelEscalamedicioncondicion>();
}
