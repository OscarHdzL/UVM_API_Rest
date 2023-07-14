using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwConfEscalaMedicionBase
{
    public int Id { get; set; }

    public int ConfIndicadorSiacId { get; set; }

    public int? ConfElementoEvaluacionId { get; set; }

    public int? CatIndicadorSiacId { get; set; }

    public string? ClaveIndicadorSiac { get; set; }

    public string? IndicadorSiac { get; set; }

    public int? ComponenteUvmId { get; set; }

    public string? NombreComponenteUvm { get; set; }

    public string? DescripcionComponenteUvm { get; set; }

    public int? IndicadorUvmId { get; set; }

    public string? NombreIndicadorUvm { get; set; }

    public int? SubindicadorUvmId { get; set; }

    public string? NombreSubIndicadorUvm { get; set; }

    public int? CatPeriodoEvaluacionId { get; set; }

    public int? Anio { get; set; }

    public int? IdCiclo { get; set; }

    public string? Ciclo { get; set; }

    public int? IdInstitucion { get; set; }

    public string? Institucion { get; set; }

    public string? Proceso { get; set; }

    public int? CatAreaResponsableId { get; set; }

    public string? AreaResponsable { get; set; }

    public int? CatNivelModalidadId { get; set; }

    public string? NivelModalidad { get; set; }

    public int? CatComponenteId { get; set; }

    public string? ClaveComponente { get; set; }

    public string? Componente { get; set; }

    public int? CatElementoEvaluacionId { get; set; }

    public string? ClaveElementoEvaluacion { get; set; }

    public string? ElementoEvaluacion { get; set; }

    public int? CatAreaCorporativaId { get; set; }

    public string? SiglasAreaCorporativa { get; set; }

    public string? AreaCorporativa { get; set; }

    public int? CatSubAreaCorporativaId { get; set; }

    public string? SubAreaCorporativa { get; set; }

    public string? SiglasSubAreaCorporativa { get; set; }

    public int? CatNormativaId { get; set; }

    public string? ClaveNormativa { get; set; }

    public string? NombreNormativa { get; set; }

    public int? CatEvidenciaId { get; set; }

    public bool? Activo { get; set; }

    public string? ClaveEvidencia { get; set; }

    public string? NombreEvidencia { get; set; }

    public string? DescripcionEvidencia { get; set; }

    public int? CantidadEvidencia { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
