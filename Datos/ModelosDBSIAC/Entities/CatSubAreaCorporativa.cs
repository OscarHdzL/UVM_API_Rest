using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatSubAreaCorporativa
{
    public int Id { get; set; }

    public string? Siglas { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<ConfElementoEvaluacion> ConfElementoEvaluacions { get; set; } = new List<ConfElementoEvaluacion>();

    public virtual ICollection<RelAreacorporativasubarea> RelAreacorporativasubareas { get; set; } = new List<RelAreacorporativasubarea>();
}
