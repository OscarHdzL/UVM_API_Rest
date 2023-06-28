using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatAreaResponsable
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? AreaResponsablePadre { get; set; }

    public bool Generica { get; set; }

    public bool Consolidacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public int? CatDependenciaAreaId { get; set; }

    public virtual CatAreaResponsable? AreaResponsablePadreNavigation { get; set; }

    public virtual ICollection<ConfElementoEvaluacion> ConfElementoEvaluacions { get; set; } = new List<ConfElementoEvaluacion>();

    public virtual ICollection<CatAreaResponsable> InverseAreaResponsablePadreNavigation { get; set; } = new List<CatAreaResponsable>();

    public virtual ICollection<RelArearesponsablenivelmodalidad> RelArearesponsablenivelmodalidads { get; set; } = new List<RelArearesponsablenivelmodalidad>();
}
