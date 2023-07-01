using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelConfindicadorsiacfile
{
    public int Id { get; set; }

    public int ConfIndicadorSiacId { get; set; }

    public int AzureStorageFileId { get; set; }
}
