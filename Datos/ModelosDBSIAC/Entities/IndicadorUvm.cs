using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class IndicadorUvm
{
    public int Id { get; set; }

    public int ComponenteUvmId { get; set; }

    public string NombreIndicadorUvm { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ComponenteUvm ComponenteUvm { get; set; } = null!;

    public virtual ICollection<ConfIndicadorSiac> ConfIndicadorSiacs { get; set; } = new List<ConfIndicadorSiac>();

    public virtual ICollection<SubIndicadorUvm> SubIndicadorUvms { get; set; } = new List<SubIndicadorUvm>();
}
