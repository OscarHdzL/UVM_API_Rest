using Datos.ModelosDBSIAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class ConfiguracionElementoEvaluacionResponseDTO
    {
        public int Id { get; set; }

        public int CatPeriodoEvaluacionId { get; set; }

        public int? Anio { get; set; }

        public int? IdCiclo { get; set; }

        public string? Ciclo { get; set; }

        public int? IdInstitucion { get; set; }

        public string? Institucion { get; set; }

        public string? Proceso { get; set; }

        public int CatAreaResponsableId { get; set; }

        public string? AreaResponsable { get; set; }

        public int CatNivelModalidadId { get; set; }

        public string NivelModalidad { get; set; } = null!;

        public int CatComponenteId { get; set; }

        public string? ClaveComponente { get; set; }

        public string? Componente { get; set; }

        public int CatElementoEvaluacionId { get; set; }

        public string? ClaveElementoEvaluacion { get; set; }

        public string? ElementoEvaluacion { get; set; }

        public int CatAreaCorporativaId { get; set; }

        public string? SiglasAreaCorporativa { get; set; }

        public string? AreaCorporativa { get; set; }

        public string? SubareasAreaCorporativa { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
        public List<VwConfElementoEvaluacionFile> ListaArchivos { get; set; } = new List<VwConfElementoEvaluacionFile>();

    }

}
