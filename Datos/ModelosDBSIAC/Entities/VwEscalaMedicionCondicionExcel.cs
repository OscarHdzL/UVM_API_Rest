using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwEscalaMedicionCondicionExcel
{
    public string? ClaveIndicadorSiac { get; set; }

    public string? IndicadorSiac { get; set; }

    public string? NombreComponenteUvm { get; set; }

    public string? DescripcionComponenteUvm { get; set; }

    public string? NombreIndicadorUvm { get; set; }

    public string? NombreSubIndicadorUvm { get; set; }

    public string? Escala { get; set; }

    public string? Nombre { get; set; }

    public string Condicion { get; set; } = null!;
}
