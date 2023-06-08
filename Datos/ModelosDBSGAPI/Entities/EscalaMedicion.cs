using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class EscalaMedicion
{
    public int EscalaMedicionId { get; set; }

    public int Anio { get; set; }

    public string CicloId { get; set; } = null!;

    public bool Generica { get; set; }

    public int AreaResponsableId { get; set; }

    public string NivelModalidadId { get; set; } = null!;

    public string ComponenteId { get; set; } = null!;

    public int ElementoEvaluacionId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual AreaResponsable AreaResponsable { get; set; } = null!;

    public virtual Ciclo Ciclo { get; set; } = null!;

    public virtual Componente Componente { get; set; } = null!;

    public virtual ElementoEvaluacion ElementoEvaluacion { get; set; } = null!;

    public virtual ICollection<EscalaMedicionEscenario> EscalaMedicionEscenarios { get; set; } = new List<EscalaMedicionEscenario>();

    public virtual NivelModalidad NivelModalidad { get; set; } = null!;
}
