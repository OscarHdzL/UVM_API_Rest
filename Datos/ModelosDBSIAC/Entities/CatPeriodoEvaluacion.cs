using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatPeriodoEvaluacion
{
    public int Id { get; set; }

    public int Anio { get; set; }

    public int CicloId { get; set; }

    public int CatInstitucionId { get; set; }

    public string Proceso { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatInstitucion CatInstitucion { get; set; } = null!;

    public virtual Ciclo Ciclo { get; set; } = null!;

    public virtual ICollection<ConfElementoEvaluacion> ConfElementoEvaluacions { get; set; } = new List<ConfElementoEvaluacion>();
}
