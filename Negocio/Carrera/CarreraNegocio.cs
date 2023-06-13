
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
using Datos.Modelos;

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

                //var resultados = await ctx.Carreras.Where(x=>x.Activo == true).ToListAsync();

               


                var resultados2 = await (from x in ctx.Carreras
                                         where
                                         x.Activo == true
                                         select new CarreraDTO
                                         {
                                             CarreraId = x.CarreraId,
                                             Nombre = x.Nombre,
                                             Plan = x.Plan,
                                             Activo = x.Activo,
                                             FechaCreacion = x.FechaCreacion,
                                             UsuarioCreacion = x.UsuarioCreacion,
                                             FechaModificacion = x.FechaModificacion,
                                             UsuarioModificacion = x.UsuarioModificacion

                                         }
                         ).ToListAsync();

                this.Respuesta = TipoAccion.Positiva(resultados2);



            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;
        }


        


    }
}
