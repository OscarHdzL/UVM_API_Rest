
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
    public class ConfiguracionIndicadorSIACNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwConfIndicadorSiacs.FromSqlInterpolated($@"EXEC sp_ConfiguracionIndicadorSIAC_Select @TipoConsulta={"ConfiguracionIndicadorSIACLista"}, @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();



                List<ConfiguracionIndicadorSiacResponseDTO> lista = new List<ConfiguracionIndicadorSiacResponseDTO>();

                foreach (VwConfIndicadorSiac item in resultados)
                {
                    ConfiguracionIndicadorSiacResponseDTO obj = new ConfiguracionIndicadorSiacResponseDTO();
                    obj.Id = item.Id;
                    obj.ConfElementoEvaluacionId = item.ConfElementoEvaluacionId;
                    obj.CatIndicadorSiacId = item.CatIndicadorSiacId;
                    obj.ClaveIndicadorSiac = item.ClaveIndicadorSiac;
                    obj.IndicadorSiac = item.IndicadorSiac;
                    obj.ComponenteUvmId = item.ComponenteUvmId;
                    obj.NombreComponenteUvm = item.NombreComponenteUvm;
                    obj.DescripcionComponenteUvm = item.DescripcionComponenteUvm;
                    obj.IndicadorUvmId = item.IndicadorUvmId;
                    obj.NombreIndicadorUvm = item.NombreIndicadorUvm;
                    obj.SubindicadorUvmId = item.SubindicadorUvmId;
                    obj.NombreSubIndicadorUvm = item.NombreSubIndicadorUvm;
                    obj.CatPeriodoEvaluacionId = item.CatPeriodoEvaluacionId;
                    obj.Anio = item.Anio;
                    obj.IdCiclo = item.IdCiclo;
                    obj.Ciclo = item.Ciclo;
                    obj.IdInstitucion = item.IdInstitucion;
                    obj.Institucion = item.Institucion;
                    obj.Proceso = item.Proceso;
                    obj.CatAreaResponsableId = item.CatAreaResponsableId;
                    obj.AreaResponsable = item.AreaResponsable;
                    obj.CatNivelModalidadId = item.CatNivelModalidadId;
                    obj.NivelModalidad = item.NivelModalidad;
                    obj.CatComponenteId = item.CatComponenteId;
                    obj.ClaveComponente = item.ClaveComponente;
                    obj.Componente = item.Componente;
                    obj.CatElementoEvaluacionId = item.CatElementoEvaluacionId;
                    obj.ClaveElementoEvaluacion = item.ClaveElementoEvaluacion;
                    obj.ElementoEvaluacion = item.ElementoEvaluacion;
                    obj.CatAreaCorporativaId = item.CatAreaCorporativaId;
                    obj.SiglasAreaCorporativa = item.SiglasAreaCorporativa;
                    obj.AreaCorporativa = item.AreaCorporativa;
                    obj.SubareasAreaCorporativa = item.SubareasAreaCorporativa;
                    obj.CatNormativaId = item.CatNormativaId;
                    obj.ClaveNormativa = item.ClaveNormativa;
                    obj.NombreNormativa = item.NombreNormativa;
                    obj.CatEvidenciaId = item.CatEvidenciaId;
                    obj.Activo = item.Activo;
                    obj.ClaveEvidencia = item.ClaveEvidencia;
                    obj.NombreEvidencia = item.NombreEvidencia;
                    obj.DescripcionEvidencia = item.DescripcionEvidencia;
                    obj.CantidadEvidencia = item.CantidadEvidencia;
                    obj.FechaCreacion = item.FechaCreacion;
                    obj.UsuarioCreacion = item.UsuarioCreacion;
                    obj.FechaModificacion = item.FechaModificacion;
                    obj.UsuarioModificacion = item.UsuarioModificacion;

                    obj.ListaArchivos = await ctx.VwConfIndicadorSiacFiles.FromSqlInterpolated($@"EXEC sp_ConfiguracionIndicadorSIAC_Select @TipoConsulta={"ConfiguracionIndicadorSIACFiles"}, @Id = {obj.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                    lista.Add(obj);
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

                var resultados = await ctx.VwConfIndicadorSiacs.FromSqlInterpolated($@"EXEC sp_ConfiguracionIndicadorSIAC_Select @TipoConsulta={"ConfiguracionIndicadorSIACLista"}, @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                List<ConfiguracionIndicadorSiacResponseDTO> lista = new List<ConfiguracionIndicadorSiacResponseDTO>();

                foreach (VwConfIndicadorSiac item in resultados)
                {
                    ConfiguracionIndicadorSiacResponseDTO obj = new ConfiguracionIndicadorSiacResponseDTO();
                    obj.Id = item.Id;
                    obj.ConfElementoEvaluacionId = item.ConfElementoEvaluacionId;
                    obj.CatIndicadorSiacId = item.CatIndicadorSiacId;
                    obj.ClaveIndicadorSiac = item.ClaveIndicadorSiac;
                    obj.IndicadorSiac = item.IndicadorSiac;
                    obj.ComponenteUvmId = item.ComponenteUvmId;
                    obj.NombreComponenteUvm = item.NombreComponenteUvm;
                    obj.DescripcionComponenteUvm = item.DescripcionComponenteUvm;
                    obj.IndicadorUvmId = item.IndicadorUvmId;
                    obj.NombreIndicadorUvm = item.NombreIndicadorUvm;
                    obj.SubindicadorUvmId = item.SubindicadorUvmId;
                    obj.NombreSubIndicadorUvm = item.NombreSubIndicadorUvm;
                    obj.CatPeriodoEvaluacionId = item.CatPeriodoEvaluacionId;
                    obj.Anio = item.Anio;
                    obj.IdCiclo = item.IdCiclo;
                    obj.Ciclo = item.Ciclo;
                    obj.IdInstitucion = item.IdInstitucion;
                    obj.Institucion = item.Institucion;
                    obj.Proceso = item.Proceso;
                    obj.CatAreaResponsableId = item.CatAreaResponsableId;
                    obj.AreaResponsable = item.AreaResponsable;
                    obj.CatNivelModalidadId = item.CatNivelModalidadId;
                    obj.NivelModalidad = item.NivelModalidad;
                    obj.CatComponenteId = item.CatComponenteId;
                    obj.ClaveComponente = item.ClaveComponente;
                    obj.Componente = item.Componente;
                    obj.CatElementoEvaluacionId = item.CatElementoEvaluacionId;
                    obj.ClaveElementoEvaluacion = item.ClaveElementoEvaluacion;
                    obj.ElementoEvaluacion = item.ElementoEvaluacion;
                    obj.CatAreaCorporativaId = item.CatAreaCorporativaId;
                    obj.SiglasAreaCorporativa = item.SiglasAreaCorporativa;
                    obj.AreaCorporativa = item.AreaCorporativa;
                    obj.SubareasAreaCorporativa = item.SubareasAreaCorporativa;
                    obj.CatNormativaId = item.CatNormativaId;
                    obj.ClaveNormativa = item.ClaveNormativa;
                    obj.NombreNormativa = item.NombreNormativa;
                    obj.CatEvidenciaId = item.CatEvidenciaId;
                    obj.Activo = item.Activo;
                    obj.ClaveEvidencia = item.ClaveEvidencia;
                    obj.NombreEvidencia = item.NombreEvidencia;
                    obj.DescripcionEvidencia = item.DescripcionEvidencia;
                    obj.CantidadEvidencia = item.CantidadEvidencia;
                    obj.FechaCreacion = item.FechaCreacion;
                    obj.UsuarioCreacion = item.UsuarioCreacion;
                    obj.FechaModificacion = item.FechaModificacion;
                    obj.UsuarioModificacion = item.UsuarioModificacion;
                    obj.ListaArchivos = await ctx.VwConfIndicadorSiacFiles.FromSqlInterpolated($@"EXEC sp_ConfiguracionIndicadorSIAC_Select @TipoConsulta={"ConfiguracionIndicadorSIACFiles"}, @Id = {obj.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();
                    lista.Add(obj);
                };

                Respuesta = TipoAccion.Positiva(lista);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(ConfiguracionIndicadorSiacDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionIndicadorSIAC_Actualiza
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


        public async Task<TipoAccion> Actualizar(ConfiguracionIndicadorSiacDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionIndicadorSIAC_Actualiza
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
                ConfiguracionIndicadorSiacDTO entidad = new ConfiguracionIndicadorSiacDTO();
                entidad.Id = id;
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionIndicadorSIAC_Actualiza
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
