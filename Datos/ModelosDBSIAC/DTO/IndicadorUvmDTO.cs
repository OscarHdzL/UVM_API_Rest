using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class IndicadorUvmDTO
    {
        public int Id { get; set; }

        public int ComponenteUvmId { get; set; }

        public string NombreIndicadorUvm { get; set; } = null!;

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
