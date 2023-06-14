
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
    public class CatPeriodoEvaluacionNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                List<CatPeriodoEvaluacion> lista = new List<CatPeriodoEvaluacion>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatPeriodoEvaluacions.FromSqlInterpolated($@"EXEC sp_PeriodoEvaluacion_Select @Id={null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
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
                List<CatPeriodoEvaluacion> lista = new List<CatPeriodoEvaluacion>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwCatPeriodoEvaluacions.FromSqlInterpolated($@"EXEC sp_PeriodoEvaluacion_Select @Id={id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(PeriodoEvaluacionDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_PeriodoEvaluacion_Actualiza
                                    @TipoActualiza = {"I"}, @Id = {0}, 
                                    @AnioID = {entidad.AnioId}, 
                                    @CicloID = {entidad.CicloId}, 
                                    @FechaInicialMeta = {entidad.FechaInicialMeta}, 
                                    @FechaFinMeta = {entidad.FechaFinMeta}, 
                                    @FechaInicialCapturaResultados = {entidad.FechaInicialCapturaResultados},
                                    @FechaFinCapturaResultados = {entidad.FechaFinCapturaResultados}, 
                                    @FechaInicialCargaEvidencia = {entidad.FechaInicialCargaEvidencia}, 
                                    @FechaFinCargaEvidencia = {entidad.FechaFinCargaEvidencia},
                                    @FechaInicialAutoEvaluacion = {entidad.FechaInicialAutoEvaluacion},
                                    @FechaFinAutoEvaluacion = {entidad.FechaFinAutoEvaluacion},
                                    @FechaInicialRevision = {entidad.FechaInicialRevision},
                                    @FechaFinRevision = {entidad.FechaFinRevision},
                                    @FechaInicialPlanMejora = {entidad.FechaInicialPlanMejora},
                                    @FechaFinPlanMejora = {entidad.FechaFinPlanMejora},
                                    @FechaInicialAuditoria = {entidad.FechaInicialAuditoria},
                                    @FechaFinAuditoria = {entidad.FechaFinAuditoria},
                                    @Activo = {entidad.Activo}, @FechaCreacion = {entidad.FechaCreacion}, 
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


        public async Task<TipoAccion> Actualizar(PeriodoEvaluacionDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;

                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_PeriodoEvaluacion_Actualiza
                                    @TipoActualiza = {"U"}, @Id = {entidad.Id}, 
                                    @AnioID = {entidad.AnioId}, 
                                    @CicloID = {entidad.CicloId}, 
                                    @FechaInicialMeta = {entidad.FechaInicialMeta}, 
                                    @FechaFinMeta = {entidad.FechaFinMeta}, 
                                    @FechaInicialCapturaResultados = {entidad.FechaInicialCapturaResultados},
                                    @FechaFinCapturaResultados = {entidad.FechaFinCapturaResultados}, 
                                    @FechaInicialCargaEvidencia = {entidad.FechaInicialCargaEvidencia}, 
                                    @FechaFinCargaEvidencia = {entidad.FechaFinCargaEvidencia},
                                    @FechaInicialAutoEvaluacion = {entidad.FechaInicialAutoEvaluacion},
                                    @FechaFinAutoEvaluacion = {entidad.FechaFinAutoEvaluacion},
                                    @FechaInicialRevision = {entidad.FechaInicialRevision},
                                    @FechaFinRevision = {entidad.FechaFinRevision},
                                    @FechaInicialPlanMejora = {entidad.FechaInicialPlanMejora},
                                    @FechaFinPlanMejora = {entidad.FechaFinPlanMejora},
                                    @FechaInicialAuditoria = {entidad.FechaInicialAuditoria},
                                    @FechaFinAuditoria = {entidad.FechaFinAuditoria},
                                    @Activo = {entidad.Activo}, @FechaCreacion = {entidad.FechaCreacion}, 
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


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_PeriodoEvaluacion_Actualiza
                                    @TipoActualiza = {"D"}, @Id = {id}, 
                                    @AnioID = {null}, 
                                    @CicloID = {null}, 
                                    @FechaInicialMeta = {null}, 
                                    @FechaFinMeta = {null}, 
                                    @FechaInicialCapturaResultados = {null},
                                    @FechaFinCapturaResultados = {null}, 
                                    @FechaInicialCargaEvidencia = {null}, 
                                    @FechaFinCargaEvidencia = {null},
                                    @FechaInicialAutoEvaluacion = {null},
                                    @FechaFinAutoEvaluacion = {null},
                                    @FechaInicialRevision = {null},
                                    @FechaFinRevision = {null},
                                    @FechaInicialPlanMejora = {null},
                                    @FechaFinPlanMejora = {null},
                                    @FechaInicialAuditoria = {null},
                                    @FechaFinAuditoria = {null},
                                    @Activo = {false}, @FechaCreacion = {null}, 
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
