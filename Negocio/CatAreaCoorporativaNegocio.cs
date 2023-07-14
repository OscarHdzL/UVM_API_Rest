
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
    public class CatAreaCoorporativaNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatAreaCorporativas.FromSqlInterpolated($@"EXEC sp_AreaCorporativa_Select @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                List<AreaCorporativaResponseDTO> lista = new List<AreaCorporativaResponseDTO>();
                

                foreach (var item in resultados) {
                    AreaCorporativaResponseDTO obj = new AreaCorporativaResponseDTO();
                    obj.Id = item.Id;
                    obj.Siglas = item.Siglas;
                    obj.Nombre= item.Nombre;
                    obj.Activo= item.Activo;
                    obj.FechaCreacion= item.FechaCreacion;
                    obj.UsuarioCreacion= item.UsuarioCreacion;
                    obj.FechaModificacion= item.FechaModificacion;
                    obj.UsuarioModificacion=item.UsuarioModificacion;
                    obj.Subareas = item.Subareas;
                    obj.SubareasIds= item.SubareasIds;
                    obj.subCorporateAreas = await ctx.VwCatSubAreaCorporativas.FromSqlInterpolated($@"EXEC sp_SubAreaCorporativa_AreaCorporativa_Select @Id = {item.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                    lista.Add(obj);
                }

                Respuesta = TipoAccion.Positiva(lista);

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

                var resultados = await ctx.VwCatAreaCorporativas.FromSqlInterpolated($@"EXEC sp_AreaCorporativa_Select @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                List<AreaCorporativaResponseDTO> lista = new List<AreaCorporativaResponseDTO>();


                foreach (var item in resultados)
                {
                    AreaCorporativaResponseDTO obj = new AreaCorporativaResponseDTO();
                    obj.Id = item.Id;
                    obj.Siglas = item.Siglas;
                    obj.Nombre = item.Nombre;
                    obj.Activo = item.Activo;
                    obj.FechaCreacion = item.FechaCreacion;
                    obj.UsuarioCreacion = item.UsuarioCreacion;
                    obj.FechaModificacion = item.FechaModificacion;
                    obj.UsuarioModificacion = item.UsuarioModificacion;
                    obj.Subareas = item.Subareas;
                    obj.SubareasIds = item.SubareasIds;
                    obj.subCorporateAreas = await ctx.VwCatSubAreaCorporativas.FromSqlInterpolated($@"EXEC sp_SubAreaCorporativa_AreaCorporativa_Select @Id = {item.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                    lista.Add(obj);
                }

                Respuesta = TipoAccion.Positiva(lista);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(AreaCorporativaDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                //await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AreaCorporativa_Actualiza
                //                    @TipoActualiza = {"I"}, 
                //                    @Id = {0}, 
                //                    @Nombre = {entidad.Nombre}, 
                //                    @Activo = {entidad.Activo}, 
                //                    @FechaCreacion = {entidad.FechaCreacion}, 
                //                    @UsuarioCreacion = {entidad.UsuarioCreacion}, 
                //                    @FechaModificacion = {entidad.FechaModificacion}, 
                //                    @UsuarioModificacion = {entidad.UsuarioModificacion}, 
                //                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AreaCorporativa_Actualiza
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


        public async Task<TipoAccion> Actualizar(AreaCorporativaDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                //await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AreaCorporativa_Actualiza
                //                    @TipoActualiza = {"U"}, 
                //                    @Id = {entidad.Id}, 
                //                    @Nombre = {entidad.Nombre}, 
                //                    @Activo = {entidad.Activo}, 
                //                    @FechaCreacion = {entidad.FechaCreacion}, 
                //                    @UsuarioCreacion = {entidad.UsuarioCreacion}, 
                //                    @FechaModificacion = {entidad.FechaModificacion}, 
                //                    @UsuarioModificacion = {entidad.UsuarioModificacion}, 
                //                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");

                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AreaCorporativa_Actualiza
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

                AreaCorporativaDTO entidad = new AreaCorporativaDTO();
                entidad.Id = id;

                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                //await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AreaCorporativa_Actualiza
                //                    @TipoActualiza = {"D"}, @Id = {id}, @Nombre = {null}, @Activo = {null}, @FechaCreacion = {null}, 
                //                    @UsuarioCreacion = {null}, @FechaModificacion = {null}, 
                //                    @UsuarioModificacion = {null}, 
                //                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");

                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AreaCorporativa_Actualiza
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
