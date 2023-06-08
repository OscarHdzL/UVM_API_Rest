
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Respuesta;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Datos.ModelosDBSIAC.Entities;
using Datos.ModelosDBSGAPI.Entities;

namespace Negocio
{
    public class CapitulosNegocio
    {
        public AppSGAPIDbContext ctx = new AppSGAPIDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                List<CatSede> lista = new List<CatSede>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                //var resultados = await ctx.Capitulos.FromSqlInterpolated($@"EXEC sp_Sede_Select @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                var resultados = await ctx.Capitulos.Where(x => x.AcreditadoraProcesoId == id).ToListAsync();

                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



    }
}
