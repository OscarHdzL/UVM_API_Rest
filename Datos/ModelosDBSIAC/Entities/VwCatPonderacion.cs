using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwCatPonderacion
{
    public int Id { get; set; }

    public int ComponenteId { get; set; }

    public int IdNivelModalidad { get; set; }

    public string? Nivel { get; set; }

    public string? Modalidad { get; set; }

    public string NivelModalidad { get; set; } = null!;

    public int Puntuacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
