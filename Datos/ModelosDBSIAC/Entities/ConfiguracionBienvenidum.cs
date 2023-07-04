using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class ConfiguracionBienvenidum
{
    public int Id { get; set; }

    public string HtmlBienvenida { get; set; } = null!;
}
