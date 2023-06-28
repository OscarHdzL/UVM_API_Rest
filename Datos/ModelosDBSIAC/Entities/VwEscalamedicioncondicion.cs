using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwEscalaMedicionCondicion
{
    public int EscalaMedicionCondicionId { get; set; }

    public int ConfEscalaMedicionId { get; set; }

    public int CatEscalaMedicionId { get; set; }

    public string? Escala { get; set; }

    public string? Nombre { get; set; }

    public string Condicion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
