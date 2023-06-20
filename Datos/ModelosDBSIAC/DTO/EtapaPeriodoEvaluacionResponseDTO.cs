using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class EtapaPeriodoEvaluacionResponseDTO
    {
        public int Id { get; set; }

        public int IdEtapa { get; set; }

        public string Etapa { get; set; } = null!;

        public int IdPeriodoEvaluacion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
