using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelEscalamedicioncondicion
{
    public int Id { get; set; }

    public int ConfEscalaMedicionId { get; set; }

    public int CatEscalaMedicionId { get; set; }

    public string Condicion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatEscalaMedicion CatEscalaMedicion { get; set; } = null!;

    public virtual ConfEscalaMedicion ConfEscalaMedicion { get; set; } = null!;
}
