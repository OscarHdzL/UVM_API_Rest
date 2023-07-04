
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
using System.Text.Json;

namespace Negocio
{
    public class CatSubAreaCoorporativaNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatSubAreaCorporativas.FromSqlInterpolated($@"EXEC sp_SubAreaCorporativa_Select @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

        public async Task<TipoAccion> GetById(int id, int pageSize, int pageNumber)
        {
            try
            {

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatSubAreaCorporativas.FromSqlInterpolated($@"EXEC sp_SubAreaCorporativa_Select @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

        


            public async Task<TipoAccion> GetByAreaCorporativa(int id, int pageSize, int pageNumber)
        {
            try
            {

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatSubAreaCorporativas.FromSqlInterpolated($@"EXEC sp_SubAreaCorporativa_AreaCorporativa_Select @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

        public async Task<TipoAccion> Insertar(SubAreaCorporativaDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_SubAreaCorporativa_Actualiza
                                    @TipoActualiza = {"I"},
                                    @Entidad = {JsonSerializer.Serialize(entidad)}, 
                                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                Respuesta = new TipoAccion();
                Respuesta.id = (int)parametroId.Value;
                Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                Respuesta.Mensaje = (string)parametroMensaje.Value;


            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;

        }


        public async Task<TipoAccion> Actualizar(SubAreaCorporativaDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_SubAreaCorporativa_Actualiza
                                    @TipoActualiza = {"U"},
                                    @Entidad = {JsonSerializer.Serialize(entidad)}, 
                                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                Respuesta = new TipoAccion();
                Respuesta.id = (int)parametroId.Value;
                Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                Respuesta.Mensaje = (string)parametroMensaje.Value;

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;

        }

        public async Task<TipoAccion> Deshabilitar(int id)
        {
            try
            {

                SubAreaCorporativaDTO entidad = new SubAreaCorporativaDTO();
                entidad.Id = id;

                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_SubAreaCorporativa_Actualiza
                                    @TipoActualiza = {"D"},
                                    @Entidad = {JsonSerializer.Serialize(entidad)}, 
                                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                Respuesta = new TipoAccion();
                Respuesta.id = (int)parametroId.Value;
                Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                Respuesta.Mensaje = (string)parametroMensaje.Value;

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;

        }


    }
}
