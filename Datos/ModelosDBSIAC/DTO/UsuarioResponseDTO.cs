using Datos.ModelosDBSIAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class UsuarioResponseDTO: VwUsuarioBase
    {
        
        public List<VwUsuarioRegion> Regiones  { get; set; }
        public List<VwUsuarioCampus> Campus { get; set; }
        public List<VwUsuarioNivelModalidad> NivelesModalidad { get; set; }
        public List<VwUsuarioAreaResponsable> AreasResponsables { get; set; }
        public List<VwUsuarioAreaCorporativa> AreasCorporativas { get; set; }
        public UsuarioResponseDTO()
        {
            this.Regiones = new List<VwUsuarioRegion>();
            this.Campus = new List<VwUsuarioCampus>();
            this.NivelesModalidad = new List<VwUsuarioNivelModalidad>();
            this.AreasResponsables = new List<VwUsuarioAreaResponsable>();
            this.AreasCorporativas = new List<VwUsuarioAreaCorporativa>();
        }
    }


}
