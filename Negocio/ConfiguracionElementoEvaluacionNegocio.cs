
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
    public class ConfiguracionElementoEvaluacionNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwConfElementoEvaluacions.FromSqlInterpolated($@"EXEC sp_ConfiguracionElementoEvaluacion_Select @TipoConsulta={"ConfiguracionElementoEvaluacionLista"}, @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                List<ConfiguracionElementoEvaluacionResponseDTO> lista = new List<ConfiguracionElementoEvaluacionResponseDTO>();

                foreach (VwConfElementoEvaluacion item in resultados){ 

                    ConfiguracionElementoEvaluacionResponseDTO objeto = new ConfiguracionElementoEvaluacionResponseDTO();
                    objeto.Id = item.Id;
                    objeto.CatPeriodoEvaluacionId = item.CatPeriodoEvaluacionId;
                    objeto.Anio = item.Anio;
                    objeto.IdCiclo = item.IdCiclo;
                    objeto.Ciclo = item.Ciclo;
                    objeto.IdInstitucion = item.IdInstitucion;
                    objeto.Institucion = item.Institucion;
                    objeto.Proceso = item.Proceso;
                    objeto.CatAreaResponsableId = item.CatAreaResponsableId;
                    objeto.AreaResponsable = item.AreaResponsable;
                    objeto.CatNivelModalidadId = item.CatNivelModalidadId;
                    objeto.NivelModalidad = item.NivelModalidad;
                    objeto.CatComponenteId = item.CatComponenteId;
                    objeto.ClaveComponente = item.ClaveComponente;
                    objeto.Componente = item.Componente;
                    objeto.CatElementoEvaluacionId = item.CatElementoEvaluacionId;
                    objeto.ClaveElementoEvaluacion = item.ClaveElementoEvaluacion;
                    objeto.ElementoEvaluacion = item.ElementoEvaluacion;
                    objeto.CatAreaCorporativaId = item.CatAreaCorporativaId;
                    objeto.SiglasAreaCorporativa = item.SiglasAreaCorporativa;
                    objeto.AreaCorporativa = item.AreaCorporativa;
                    objeto.SubareasAreaCorporativa = item.SubareasAreaCorporativa;

                    objeto.Activo = item.Activo;
                    objeto.FechaCreacion = item.FechaCreacion;
                    objeto.UsuarioCreacion = item.UsuarioCreacion;
                    objeto.FechaModificacion = item.FechaModificacion;
                    objeto.UsuarioModificacion = item.UsuarioModificacion;
                    objeto.ListaArchivos = await ctx.VwConfElementoEvaluacionFiles.FromSqlInterpolated($@"EXEC sp_ConfiguracionElementoEvaluacion_Select @TipoConsulta={"ConfiguracionElementoEvaluacionFiles"}, @Id = {objeto.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                    lista.Add(objeto);
                };




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

                var resultados = await ctx.VwConfElementoEvaluacions.FromSqlInterpolated($@"EXEC sp_ConfiguracionElementoEvaluacion_Select @TipoConsulta={"ConfiguracionElementoEvaluacionLista"}, @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                List<ConfiguracionElementoEvaluacionResponseDTO> lista = new List<ConfiguracionElementoEvaluacionResponseDTO>();

                foreach (VwConfElementoEvaluacion item in resultados)
                {

                    ConfiguracionElementoEvaluacionResponseDTO objeto = new ConfiguracionElementoEvaluacionResponseDTO();
                    objeto.Id = item.Id;
                    objeto.CatPeriodoEvaluacionId = item.CatPeriodoEvaluacionId;
                    objeto.Anio = item.Anio;
                    objeto.IdCiclo = item.IdCiclo;
                    objeto.Ciclo = item.Ciclo;
                    objeto.IdInstitucion = item.IdInstitucion;
                    objeto.Institucion = item.Institucion;
                    objeto.Proceso = item.Proceso;
                    objeto.CatAreaResponsableId = item.CatAreaResponsableId;
                    objeto.AreaResponsable = item.AreaResponsable;
                    objeto.CatNivelModalidadId = item.CatNivelModalidadId;
                    objeto.NivelModalidad = item.NivelModalidad;
                    objeto.CatComponenteId = item.CatComponenteId;
                    objeto.ClaveComponente = item.ClaveComponente;
                    objeto.Componente = item.Componente;
                    objeto.CatElementoEvaluacionId = item.CatElementoEvaluacionId;
                    objeto.ClaveElementoEvaluacion = item.ClaveElementoEvaluacion;
                    objeto.ElementoEvaluacion = item.ElementoEvaluacion;
                    objeto.CatAreaCorporativaId = item.CatAreaCorporativaId;
                    objeto.SiglasAreaCorporativa = item.SiglasAreaCorporativa;
                    objeto.AreaCorporativa = item.AreaCorporativa;
                    objeto.SubareasAreaCorporativa = item.SubareasAreaCorporativa;
                    //objeto.CatNormativaId = item.CatNormativaId;
                    //objeto.ClaveNormativa = item.ClaveNormativa;
                    //objeto.Normativa = item.Normativa;
                    //objeto.Evidencia = item.Evidencia;
                    //objeto.Descripcion = item.Descripcion;
                    //objeto.Cantidad = item.Cantidad;
                    objeto.Activo = item.Activo;
                    objeto.FechaCreacion = item.FechaCreacion;
                    objeto.UsuarioCreacion = item.UsuarioCreacion;
                    objeto.FechaModificacion = item.FechaModificacion;
                    objeto.UsuarioModificacion = item.UsuarioModificacion;
                    objeto.ListaArchivos = await ctx.VwConfElementoEvaluacionFiles.FromSqlInterpolated($@"EXEC sp_ConfiguracionElementoEvaluacion_Select @TipoConsulta={"ConfiguracionElementoEvaluacionFiles"}, @Id = {objeto.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                    lista.Add(objeto);
                };




                Respuesta = TipoAccion.Positiva(lista);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(ConfiguracionElementoEvaluacionDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionElementoEvaluacion_Actualiza
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


        public async Task<TipoAccion> Actualizar(ConfiguracionElementoEvaluacionDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionElementoEvaluacion_Actualiza
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
                ConfiguracionElementoEvaluacionDTO entidad = new ConfiguracionElementoEvaluacionDTO();
                entidad.Id = id;

                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionElementoEvaluacion_Actualiza
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
