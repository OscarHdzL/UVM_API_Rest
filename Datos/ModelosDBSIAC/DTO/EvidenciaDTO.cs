﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class EvidenciaDTO
    {
        public int Id { get; set; }

        public string Clave { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int Cantidad { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

    }
}
