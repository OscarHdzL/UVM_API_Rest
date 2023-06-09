
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Respuesta;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Datos.ModelosDBSGAPI.Entities;

namespace Negocio.Criterio
{
    public class CriterioNegocio
    {
        public AppSGAPIDbContext ctx = new AppSGAPIDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int idAcreditadoraProceso, string idCarrera)
        {
            try
            {

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.Criterios.Where(x=>x.AcreditadoraProcesoId == idAcreditadoraProceso && x.CarreraId == idCarrera).ToListAsync();
                this.Respuesta = TipoAccion.Positiva(resultados);
                
            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;
        }


        


    }
}
