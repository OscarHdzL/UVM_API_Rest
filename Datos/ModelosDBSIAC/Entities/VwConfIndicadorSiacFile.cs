using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwConfIndicadorSiacFile
{
    public int Id { get; set; }

    public int ConfIndicadorSiacId { get; set; }

    public int AzureStorageFileId { get; set; }

    public string FileName { get; set; } = null!;
}
