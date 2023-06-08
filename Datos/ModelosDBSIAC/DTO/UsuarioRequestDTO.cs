using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class UsuarioRequestDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public int CatNivelRevisionId { get; set; }
        public int TblPerfilId { get; set; }
        public bool Todos { get; set; }
        public string FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public List<int> Regiones { get; set; }
        public List<int> Campus { get; set; }
        public List<int> NivelesModalidad { get; set; }
        public List<int> AreasResponsables { get; set; }
        public List<int> AreasCorporativas { get; set; }
    }


}
