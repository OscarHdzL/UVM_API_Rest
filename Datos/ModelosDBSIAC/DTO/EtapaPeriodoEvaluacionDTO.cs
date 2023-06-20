using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class EtapaPeriodoEvaluacionDTO
    {
        public int Id { get; set; }

        public int CatEtapaId { get; set; }

        public int CatPeriodoEvaluacionId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
