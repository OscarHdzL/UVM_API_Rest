﻿
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

namespace Negocio
{
    public class CatIndicadorSIACNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                List<CatIndicadorSiac> lista = new List<CatIndicadorSiac>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatIndicadorSiacs.FromSqlInterpolated($@"EXEC sp_IndicadorSIAC_Select @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
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
                List<CatIndicadorSiac> lista = new List<CatIndicadorSiac>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatIndicadorSiacs.FromSqlInterpolated($@"EXEC sp_IndicadorSIAC_Select @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(CatIndicadorSiac entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;

                    
                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_IndicadorSIAC_Actualiza
                                    @TipoActualiza = {"I"}, @Id = {0}, @Clave = {entidad.Clave}, @Nombre = {entidad.Nombre}, @Descripcion = {entidad.Descripcion}, @Activo = {entidad.Activo}, @FechaCreacion = {entidad.FechaCreacion}, 
                                    @UsuarioCreacion = {entidad.UsuarioCreacion}, @FechaModificacion = {entidad.FechaModificacion}, 
                                    @UsuarioModificacion = {entidad.UsuarioModificacion}, 
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


        public async Task<TipoAccion> Actualizar(CatIndicadorSiac entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_IndicadorSIAC_Actualiza
                                    @TipoActualiza = {"U"}, @Id = {entidad.Id}, @Clave = {entidad.Clave}, @Nombre = {entidad.Nombre},  @Descripcion = {entidad.Descripcion}, @Activo = {entidad.Activo}, @FechaCreacion = {entidad.FechaCreacion}, 
                                    @UsuarioCreacion = {entidad.UsuarioCreacion}, @FechaModificacion = {entidad.FechaModificacion}, 
                                    @UsuarioModificacion = {entidad.UsuarioModificacion}, 
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
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_IndicadorSIAC_Actualiza
                                    @TipoActualiza = {"D"}, @Id = {id},  @Clave = {null}, @Nombre = {null}, @Descripcion = {null}, @Activo = {null}, @FechaCreacion = {null}, 
                                    @UsuarioCreacion = {null}, @FechaModificacion = {null}, 
                                    @UsuarioModificacion = {null}, 
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
