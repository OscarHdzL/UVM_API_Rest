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
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Perfil { get; set; }
        public string Campus { get; set; }
        public string Region { get; set; }
        public string AreaResponsable { get; set; }


        public List<VistasPerfilDTO> Vistas { get; set; }

        public UsuarioPerfilPermisosDTO() { 
            this.Nombre = string.Empty;
            this.Correo = string.Empty;
            this.Perfil = string.Empty;
            this.Campus = string.Empty;
            this.Region = string.Empty;
            this.AreaResponsable= string.Empty;
            this.Vistas = new List<VistasPerfilDTO>();
        }
    }

    public class VistasPerfilDTO
    {
        public int VistaId { get; set; }
        public string Nombre { get; set; }
        public string TipoVista { get; set; }

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
