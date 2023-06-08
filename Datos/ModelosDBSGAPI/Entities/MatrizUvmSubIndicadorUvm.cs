using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class MatrizUvmSubIndicadorUvm
{
    public int MatrizUvmId { get; set; }

    public int SubIndicadorUvmId { get; set; }

    public virtual MatrizUvm MatrizUvm { get; set; } = null!;

    public virtual SubIndicadorUvm SubIndicadorUvm { get; set; } = null!;
}
