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
using System.Text.Json;
using Datos.ModelosDBSIAC.DTO;

namespace Negocio
{
    public class CatCampusNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                List<CampusResponseDTO> lista = new List<CampusResponseDTO>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                //var resultados = await ctx.VwCatCampuses.FromSqlInterpolated($@"EXEC sp_Campus_Select_test @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                var resultados = await ctx.VwCatCampuses.FromSqlInterpolated($@"EXEC sp_Campus_Select @TipoConsulta = {"CampusLista"}, @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();




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
                List<CatCampus> lista = new List<CatCampus>();

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                //var resultados = await ctx.VwCatCampuses.FromSqlInterpolated($@"EXEC sp_Campus_Select_test @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                var resultados = await ctx.VwCatCampuses.FromSqlInterpolated($@"EXEC sp_Campus_Select @TipoConsulta = {"CampusLista"}, @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(CampusDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                

                //await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Campus_Actualiza
                //                    @TipoActualiza = {"I"}, @Id = {0},  @Clave = {entidad.Clave}, @Nombre = {entidad.Nombre}, @RegionId = {entidad.RegionId}, @Activo = {entidad.Activo}, @FechaCreacion = {entidad.FechaCreacion}, 
                //                    @UsuarioCreacion = {entidad.UsuarioCreacion}, @FechaModificacion = {entidad.FechaModificacion}, 
                //                    @UsuarioModificacion = {entidad.UsuarioModificacion}, 
                //                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                    await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Campus_Actualiza
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


        public async Task<TipoAccion> Actualizar(CampusDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;

                //await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Campus_Actualiza
                //                    @TipoActualiza = {"U"}, @Id = {entidad.Id},  @Clave = {entidad.Clave}, @Nombre = {entidad.Nombre}, @RegionId = {entidad.RegionId}, @Activo = {entidad.Activo}, @FechaCreacion = {entidad.FechaCreacion}, 
                //                    @UsuarioCreacion = {entidad.UsuarioCreacion}, @FechaModificacion = {entidad.FechaModificacion}, 
                //                    @UsuarioModificacion = {entidad.UsuarioModificacion}, 
                //                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");

                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Campus_Actualiza
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

                CampusDTO entidad = new CampusDTO();
                entidad.Id= id;

                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                //await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Campus_Actualiza
                //                    @TipoActualiza = {"D"}, @Id = {id},  @Clave = {null}, @Nombre = {null}, @RegionId = {null}, @Activo = {null}, @FechaCreacion = {null}, 
                //                    @UsuarioCreacion = {null}, @FechaModificacion = {null}, 
                //                    @UsuarioModificacion = {null}, 
                //                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");

                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Campus_Actualiza
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
