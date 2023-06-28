﻿using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class SubIndicadorUvm
{
    public int Id { get; set; }

    public int IndicadorUvmId { get; set; }

    public string NombreSubIndicadorUvm { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<ConfIndicadorSiac> ConfIndicadorSiacs { get; set; } = new List<ConfIndicadorSiac>();

    public virtual IndicadorUvm IndicadorUvm { get; set; } = null!;
}
