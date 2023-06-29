using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelConfelementoevaluacionfile
{
    public int Id { get; set; }

    public int ConfElementoEvaluacionId { get; set; }

    public int AzureStorageFileId { get; set; }

    public virtual AzureStorageFile AzureStorageFile { get; set; } = null!;

    public virtual ConfElementoEvaluacion ConfElementoEvaluacion { get; set; } = null!;
}
