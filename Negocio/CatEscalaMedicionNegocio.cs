
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
using Datos.ModelosDBSIAC.DTO;

namespace Negocio
{
    public class CatEscalaMedicionNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try { 

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatEscalaMedicions.FromSqlInterpolated($@"EXEC sp_EscalaMedicion_Select @TipoConsulta={"EscalaMedicionLista"}, @Id={null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
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
