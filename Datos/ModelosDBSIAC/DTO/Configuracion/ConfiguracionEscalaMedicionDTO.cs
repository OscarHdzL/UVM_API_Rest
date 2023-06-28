using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class ConfiguracionEscalaMedicionDTO
    {
        public int Id { get; set; }

        public int ConfIndicadorSiacId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public List<EscalaMedicionCondicionDTO> Condiciones { get; set; } = new List<EscalaMedicionCondicionDTO>();


    }

    public class EscalaMedicionCondicionDTO
    {
        public int EscalaMedicionCondicionId { get; set; }

        public int ConfEscalaMedicionId { get; set; }

        public int CatEscalaMedicionId { get; set; }

        public string Condicion { get; set; } = null!;

    }


}
