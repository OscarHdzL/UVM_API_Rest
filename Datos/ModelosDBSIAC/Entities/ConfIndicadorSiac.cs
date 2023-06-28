using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class ConfIndicadorSiac
{
    public int Id { get; set; }

    public int ConfElementoEvaluacionId { get; set; }

    public int CatIndicadorSiacId { get; set; }

    public int? ComponenteUvmId { get; set; }

    public int? IndicadorUvmId { get; set; }

    public int? SubindicadorUvmId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatIndicadorSiac CatIndicadorSiac { get; set; } = null!;

    public virtual ComponenteUvm? ComponenteUvm { get; set; }

    public virtual ConfElementoEvaluacion ConfElementoEvaluacion { get; set; } = null!;

    public virtual ICollection<ConfEscalaMedicion> ConfEscalaMedicions { get; set; } = new List<ConfEscalaMedicion>();

    public virtual IndicadorUvm? IndicadorUvm { get; set; }

    public virtual SubIndicadorUvm? SubindicadorUvm { get; set; }
}
