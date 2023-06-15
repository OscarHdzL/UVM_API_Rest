using Datos.ModelosDBSIAC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class UsuarioPerfilPermisosDTO
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public List<VistasPerfilDTO> Vistas { get; set; }

        public UsuarioPerfilPermisosDTO() { 
            this.Nombre = string.Empty;
            this.Correo = string.Empty;
            this.Vistas = new List<VistasPerfilDTO>();
        }
    }

    public class VistasPerfilDTO
    {
        public int VistaId { get; set; }
        public string Nombre { get; set; }

        public List<PermisoDTO> Permisos { get; set; }

        public VistasPerfilDTO()
        {
            this.VistaId = 0;
            this.Nombre = string.Empty;
            this.Permisos = new List<PermisoDTO>();
        }


    }

    public class PermisoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }


}
