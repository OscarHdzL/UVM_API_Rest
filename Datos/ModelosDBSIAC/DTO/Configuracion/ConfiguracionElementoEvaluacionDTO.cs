using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class ConfiguracionElementoEvaluacionDTO
    {
        public int Id { get; set; }

        public int CatPeriodoEvaluacionId { get; set; }

        public int CatAreaResponsableId { get; set; }

        public int CatNivelModalidadId { get; set; }

        public int CatComponenteId { get; set; }

        public int CatElementoEvaluacionId { get; set; }

        public int CatAreaCorporativaId { get; set; }

        public int CatNormativaId { get; set; }

        public string Evidencia { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int Cantidad { get; set; }

        public string? Archivo { get; set; }

        public string? NombreArchivo { get; set; }

        public string? MimeTypeArchivo { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

    }

}
