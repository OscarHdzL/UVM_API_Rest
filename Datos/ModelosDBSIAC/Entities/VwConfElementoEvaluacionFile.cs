using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class VwConfElementoEvaluacionFile
{
    public int Id { get; set; }

    public int ConfElementoEvaluacionId { get; set; }

    public int AzureStorageFileId { get; set; }

    public string FileName { get; set; } = null!;
}
