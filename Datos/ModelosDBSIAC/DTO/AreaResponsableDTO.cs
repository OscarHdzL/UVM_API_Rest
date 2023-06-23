using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class AreaResponsableDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int? AreaResponsablePadre { get; set; }

        public bool Generica { get; set; }

        public bool Consolidacion { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public int? CatDependenciaAreaId { get; set; }
        public List<int> NivelesModalidad { get; set; } = new List<int>();

    }
}
