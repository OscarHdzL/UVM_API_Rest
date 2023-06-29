using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class ConfElementoEvaluacion
{
    public int Id { get; set; }

    public int CatPeriodoEvaluacionId { get; set; }

    public int CatAreaResponsableId { get; set; }

    public int CatNivelModalidadId { get; set; }

    public int CatComponenteId { get; set; }

    public int CatElementoEvaluacionId { get; set; }

    public int CatAreaCorporativaId { get; set; }

    public int CatNormativaId { get; set; }

    public string Evidencia { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatAreaCorporativa CatAreaCorporativa { get; set; } = null!;

    public virtual CatAreaResponsable CatAreaResponsable { get; set; } = null!;

    public virtual CatComponente CatComponente { get; set; } = null!;

    public virtual CatElementoEvaluacion CatElementoEvaluacion { get; set; } = null!;

    public virtual CatNivelModalidad CatNivelModalidad { get; set; } = null!;

    public virtual CatNormativa CatNormativa { get; set; } = null!;

    public virtual CatPeriodoEvaluacion CatPeriodoEvaluacion { get; set; } = null!;

    public virtual ICollection<ConfIndicadorSiac> ConfIndicadorSiacs { get; set; } = new List<ConfIndicadorSiac>();

    public virtual ICollection<RelConfelementoevaluacionfile> RelConfelementoevaluacionfiles { get; set; } = new List<RelConfelementoevaluacionfile>();
}
