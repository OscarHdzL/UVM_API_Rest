using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwAzureStorageFile
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
