using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class MatrizUvmIndicadorUvm
{
    /// <summary>
    /// Clave de la relación de matriz uvm y matriz indicador uvm
    /// </summary>
    public int MatrizUvmId { get; set; }

    /// <summary>
    /// Clave de la relación de  matriz indicador uvm e Indicador uvm
    /// </summary>
    public int IndicadorUvmId { get; set; }

    public virtual IndicadorUvm IndicadorUvm { get; set; } = null!;

    public virtual MatrizUvm MatrizUvm { get; set; } = null!;
}
