using Datos.ModelosDBSIAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class CampusResponseDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int? IdRegion { get; set; }

        public string? Region { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public string Clave { get; set; } = null!;

        public string? NivelModalidad { get; set; }

        public List<VwCampusNivelModalidad> NivelesModalidad { get; set; } = new List<VwCampusNivelModalidad>();

    }
}
