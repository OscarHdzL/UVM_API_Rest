﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class ComponenteUvmDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Nombre del componente uvm.
        /// </summary>
        public string NombreComponenteUvm { get; set; } = null!;

        /// <summary>
        /// Descripción del componente uvm.
        /// </summary>
        public string DescripcionComponenteUvm { get; set; } = null!;

        /// <summary>
        /// Indica si el registro se encuentra activo en el sistema.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha en la que fue creado el registro.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Usuario que generó el registro.
        /// </summary>
        public string UsuarioCreacion { get; set; } = null!;

        /// <summary>
        /// Fecha de última modificación del registro.
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Usuario de última modificación del registro.
        /// </summary>
        public string? UsuarioModificacion { get; set; }
    }
}
