using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class ConfiguracionIndicadorSiacDTO
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

        public int CatNormativaId { get; set; }

        public int CatEvidenciaId { get; set; }

        public bool? Activo { get; set; }

        public List<int> Archivos { get; set; } = new List<int>();

    }

}
