using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class PeriodoEvaluacionTestDTO
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

        public List<EtapaPeriodoEvaluacionDTO> Etapas { get; set; }
    }
}
