using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class AcreditadoraProceso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Capitulo> Capitulos { get; set; } = new List<Capitulo>();

    public virtual ICollection<CatCapitulo> CatCapitulos { get; set; } = new List<CatCapitulo>();
}
