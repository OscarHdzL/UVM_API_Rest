using Datos.ModelosDBSIAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class UsuarioSidebarResponseDTO: VwUsuarioBase
    {
        
        public List<VwVistasPerfil> VistasPerfil  { get; set; }

        public UsuarioSidebarResponseDTO()
        {
            this.VistasPerfil = new List<VwVistasPerfil>();
        }
    }


}
