
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

namespace Negocio.Carrera
{
    public class CarreraNegocio
    {
        public AppSGAPIDbContext ctx = new AppSGAPIDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get()
        {
            try
            {

                var resultados = await ctx.Carreras.Where(x=>x.Activo == true).ToListAsync();
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
