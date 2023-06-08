using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class EscalaMedicionEscenario
{
    public int EscenarioId { get; set; }

    public int EscalaMedicionId { get; set; }

    public int? Valor { get; set; }

    public string? Descripcion { get; set; }

    public virtual EscalaMedicion EscalaMedicion { get; set; } = null!;
}
