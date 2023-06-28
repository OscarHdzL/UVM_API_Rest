using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class PeriodoEvaluacionResponseDTO
    {
        public int IdPeriodoEvaluacion { get; set; }

        public int Anio { get; set; }

        public int IdCiclo { get; set; }
        public string Ciclo { get; set; } = null!;

        public int IdInstitucion { get; set; }

        public string Institucion { get; set; } = null!;

        public string Proceso { get; set; } = null!;

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public List<EtapaPeriodoEvaluacionResponseDTO> Etapas { get; set; }
    }
}
