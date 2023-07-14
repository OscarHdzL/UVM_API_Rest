
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
    public class ConfiguracionEscalaMedicionNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {

                List<ConfiguracionEscalaMedicionResponseDTO> lista = new List<ConfiguracionEscalaMedicionResponseDTO>();

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwConfEscalaMedicionBases.FromSqlInterpolated($@"EXEC sp_ConfiguracionEscalaMedicion_Select @TipoConsulta={"ConfiguracionEscalaMedicionLista"}, @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();


                foreach (var escala in resultados) {
                    ConfiguracionEscalaMedicionResponseDTO escalaMedicion = new ConfiguracionEscalaMedicionResponseDTO();
                    escalaMedicion.Id = escala.Id;
                    escalaMedicion.ConfIndicadorSiacId = escala.ConfIndicadorSiacId;
                    escalaMedicion.ConfElementoEvaluacionId = escala.ConfElementoEvaluacionId;
                    escalaMedicion.CatIndicadorSiacId = escala.CatIndicadorSiacId;
                    escalaMedicion.ClaveIndicadorSiac = escala.ClaveIndicadorSiac;
                    escalaMedicion.IndicadorSiac = escala.IndicadorSiac;
                    escalaMedicion.ComponenteUvmId = escala.ComponenteUvmId;
                    escalaMedicion.NombreComponenteUvm = escala.NombreComponenteUvm;
                    escalaMedicion.DescripcionComponenteUvm = escala.DescripcionComponenteUvm;
                    escalaMedicion.IndicadorUvmId = escala.IndicadorUvmId;
                    escalaMedicion.NombreIndicadorUvm = escala.NombreIndicadorUvm;
                    escalaMedicion.SubindicadorUvmId = escala.SubindicadorUvmId;
                    escalaMedicion.NombreSubIndicadorUvm = escala.NombreSubIndicadorUvm;
                    escalaMedicion.CatPeriodoEvaluacionId = escala.CatPeriodoEvaluacionId;
                    escalaMedicion.Anio = escala.Anio;
                    escalaMedicion.IdCiclo = escala.IdCiclo;
                    escalaMedicion.Ciclo = escala.Ciclo;
                    escalaMedicion.IdInstitucion = escala.IdInstitucion;
                    escalaMedicion.Institucion = escala.Institucion;
                    escalaMedicion.Proceso = escala.Proceso;
                    escalaMedicion.CatAreaResponsableId = escala.CatAreaResponsableId;
                    escalaMedicion.AreaResponsable = escala.AreaResponsable;
                    escalaMedicion.CatNivelModalidadId = escala.CatNivelModalidadId;
                    escalaMedicion.NivelModalidad = escala.NivelModalidad;
                    escalaMedicion.CatComponenteId = escala.CatComponenteId;
                    escalaMedicion.ClaveComponente = escala.ClaveComponente;
                    escalaMedicion.Componente = escala.Componente;
                    escalaMedicion.CatElementoEvaluacionId = escala.CatElementoEvaluacionId;
                    escalaMedicion.ClaveElementoEvaluacion = escala.ClaveElementoEvaluacion;
                    escalaMedicion.ElementoEvaluacion = escala.ElementoEvaluacion;
                    escalaMedicion.CatAreaCorporativaId = escala.CatAreaCorporativaId;
                    escalaMedicion.SiglasAreaCorporativa = escala.SiglasAreaCorporativa;
                    escalaMedicion.AreaCorporativa = escala.AreaCorporativa;
                    escalaMedicion.CatSubAreaCorporativaId = escala.CatSubAreaCorporativaId;
                    escalaMedicion.SubAreaCorporativa = escala.SubAreaCorporativa;
                    escalaMedicion.SiglasSubAreaCorporativa = escala.SiglasSubAreaCorporativa;
                    escalaMedicion.CatNormativaId = escala.CatNormativaId;
                    escalaMedicion.ClaveNormativa = escala.ClaveNormativa;
                    escalaMedicion.NombreNormativa = escala.NombreNormativa;
                    escalaMedicion.CatEvidenciaId = escala.CatEvidenciaId;
                    escalaMedicion.Activo = escala.Activo;
                    escalaMedicion.ClaveEvidencia = escala.ClaveEvidencia;
                    escalaMedicion.NombreEvidencia = escala.NombreEvidencia;
                    escalaMedicion.DescripcionEvidencia = escala.DescripcionEvidencia;
                    escalaMedicion.CantidadEvidencia = escala.CantidadEvidencia;
                    escalaMedicion.FechaCreacion = escala.FechaCreacion;
                    escalaMedicion.UsuarioCreacion = escala.UsuarioCreacion;
                    escalaMedicion.FechaModificacion = escala.FechaModificacion;
                    escalaMedicion.UsuarioModificacion = escala.UsuarioModificacion;
                    escalaMedicion.Condiciones = await ctx.VwEscalaMedicionCondicions.FromSqlInterpolated($@"EXEC sp_ConfiguracionEscalaMedicion_Select @TipoConsulta={"EscalaMedicionCondicion"}, @Id = {escalaMedicion.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                    lista.Add(escalaMedicion);

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
                List<ConfiguracionEscalaMedicionResponseDTO> lista = new List<ConfiguracionEscalaMedicionResponseDTO>();
                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.VwConfEscalaMedicionBases.FromSqlInterpolated($@"EXEC sp_ConfiguracionEscalaMedicion_Select @TipoConsulta={"ConfiguracionEscalaMedicionLista"}, @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();


                foreach (var escala in resultados)
                {
                    ConfiguracionEscalaMedicionResponseDTO escalaMedicion = new ConfiguracionEscalaMedicionResponseDTO();
                    escalaMedicion.Id = escala.Id;
                    escalaMedicion.ConfIndicadorSiacId = escala.ConfIndicadorSiacId;
                    escalaMedicion.ConfElementoEvaluacionId = escala.ConfElementoEvaluacionId;
                    escalaMedicion.CatIndicadorSiacId = escala.CatIndicadorSiacId;
                    escalaMedicion.ClaveIndicadorSiac = escala.ClaveIndicadorSiac;
                    escalaMedicion.IndicadorSiac = escala.IndicadorSiac;
                    escalaMedicion.ComponenteUvmId = escala.ComponenteUvmId;
                    escalaMedicion.NombreComponenteUvm = escala.NombreComponenteUvm;
                    escalaMedicion.DescripcionComponenteUvm = escala.DescripcionComponenteUvm;
                    escalaMedicion.IndicadorUvmId = escala.IndicadorUvmId;
                    escalaMedicion.NombreIndicadorUvm = escala.NombreIndicadorUvm;
                    escalaMedicion.SubindicadorUvmId = escala.SubindicadorUvmId;
                    escalaMedicion.NombreSubIndicadorUvm = escala.NombreSubIndicadorUvm;
                    escalaMedicion.CatPeriodoEvaluacionId = escala.CatPeriodoEvaluacionId;
                    escalaMedicion.Anio = escala.Anio;
                    escalaMedicion.IdCiclo = escala.IdCiclo;
                    escalaMedicion.Ciclo = escala.Ciclo;
                    escalaMedicion.IdInstitucion = escala.IdInstitucion;
                    escalaMedicion.Institucion = escala.Institucion;
                    escalaMedicion.Proceso = escala.Proceso;
                    escalaMedicion.CatAreaResponsableId = escala.CatAreaResponsableId;
                    escalaMedicion.AreaResponsable = escala.AreaResponsable;
                    escalaMedicion.CatNivelModalidadId = escala.CatNivelModalidadId;
                    escalaMedicion.NivelModalidad = escala.NivelModalidad;
                    escalaMedicion.CatComponenteId = escala.CatComponenteId;
                    escalaMedicion.ClaveComponente = escala.ClaveComponente;
                    escalaMedicion.Componente = escala.Componente;
                    escalaMedicion.CatElementoEvaluacionId = escala.CatElementoEvaluacionId;
                    escalaMedicion.ClaveElementoEvaluacion = escala.ClaveElementoEvaluacion;
                    escalaMedicion.ElementoEvaluacion = escala.ElementoEvaluacion;
                    escalaMedicion.CatAreaCorporativaId = escala.CatAreaCorporativaId;
                    escalaMedicion.SiglasAreaCorporativa = escala.SiglasAreaCorporativa;
                    escalaMedicion.AreaCorporativa = escala.AreaCorporativa;
                    escalaMedicion.CatSubAreaCorporativaId = escala.CatSubAreaCorporativaId;
                    escalaMedicion.SubAreaCorporativa = escala.SubAreaCorporativa;
                    escalaMedicion.SiglasSubAreaCorporativa = escala.SiglasSubAreaCorporativa;
                    escalaMedicion.CatNormativaId = escala.CatNormativaId;
                    escalaMedicion.ClaveNormativa = escala.ClaveNormativa;
                    escalaMedicion.NombreNormativa = escala.NombreNormativa;
                    escalaMedicion.CatEvidenciaId = escala.CatEvidenciaId;
                    escalaMedicion.Activo = escala.Activo;
                    escalaMedicion.ClaveEvidencia = escala.ClaveEvidencia;
                    escalaMedicion.NombreEvidencia = escala.NombreEvidencia;
                    escalaMedicion.DescripcionEvidencia = escala.DescripcionEvidencia;
                    escalaMedicion.CantidadEvidencia = escala.CantidadEvidencia;
                    escalaMedicion.FechaCreacion = escala.FechaCreacion;
                    escalaMedicion.UsuarioCreacion = escala.UsuarioCreacion;
                    escalaMedicion.FechaModificacion = escala.FechaModificacion;
                    escalaMedicion.UsuarioModificacion = escala.UsuarioModificacion;
                    escalaMedicion.Condiciones = await ctx.VwEscalaMedicionCondicions.FromSqlInterpolated($@"EXEC sp_ConfiguracionEscalaMedicion_Select @TipoConsulta={"EscalaMedicionCondicion"}, @Id = {escalaMedicion.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                    lista.Add(escalaMedicion);

                }



                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



        public async Task<TipoAccion> Insertar(ConfiguracionEscalaMedicionDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionEscalaMedicion_Actualiza
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


        public async Task<TipoAccion> Actualizar(ConfiguracionEscalaMedicionDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionEscalaMedicion_Actualiza
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
                ConfiguracionEscalaMedicionDTO entidad = new ConfiguracionEscalaMedicionDTO();
                entidad.Id = id;
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_ConfiguracionEscalaMedicion_Actualiza
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
