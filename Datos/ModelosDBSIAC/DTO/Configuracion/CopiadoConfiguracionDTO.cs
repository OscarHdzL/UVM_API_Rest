using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO.Configuracion
{
    public class CopiadoConfiguracionDTO
    {
        public int CatPeriodoEvaluacionIdOrigen { get; set; }
        public int CatPeriodoEvaluacionIdDestino { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
