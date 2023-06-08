using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class ConfiguracionIndicadorSiac
{
    public int ConfiguracionIndicadorSiacId { get; set; }

    public int Anio { get; set; }

    public string CicloId { get; set; } = null!;

    public int AreaResponsableId { get; set; }

    public string NivelModalidadId { get; set; } = null!;

    public string ComponenteId { get; set; } = null!;

    public string CatalogoIndicadorSiacId { get; set; } = null!;

    public int MatrizUvmId { get; set; }

    public bool Generica { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual AreaResponsable AreaResponsable { get; set; } = null!;

    public virtual IndicadorSiac CatalogoIndicadorSiac { get; set; } = null!;

    public virtual Ciclo Ciclo { get; set; } = null!;

    public virtual Componente Componente { get; set; } = null!;

    public virtual MatrizUvm MatrizUvm { get; set; } = null!;

    public virtual NivelModalidad NivelModalidad { get; set; } = null!;
}
