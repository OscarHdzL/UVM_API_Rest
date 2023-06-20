﻿using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatInstitucion
{
    public int Id { get; set; }

    public string Institucion { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<CatPeriodoEvaluacion> CatPeriodoEvaluacions { get; set; } = new List<CatPeriodoEvaluacion>();
}
