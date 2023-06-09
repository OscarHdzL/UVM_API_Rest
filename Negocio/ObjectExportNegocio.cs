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
using Datos.ModelosDBSGAPI.Entities;
using System.Reflection;
using Spire.Xls;
using System.Drawing.Printing;
using Datos.Modelos;

namespace Negocio
{
    public class ObjectExportNegocio
    {
        public AppSIACDbContext ctx_siac = new AppSIACDbContext();
        public AppSGAPIDbContext ctx_fimpes = new AppSGAPIDbContext();


        public TipoAccion Respuesta { get; set; }


        public  DataTable Get(String SP)
        {
            DataTable dt = new DataTable();
            try
            {
                Object resultados = null;
                SP = "sp_" + SP + "_Select";
                if (SP == "sp_Region_Select")
                {
                    List<CatRegion> response = new List<CatRegion>();
                    response =  ctx_siac.CatRegions.FromSqlInterpolated($@"EXEC {SP} @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("CatCampuses");

                }
                else if (SP == "sp_Perfil_Select")
                {
                    List<TblPerfil> response = new List<TblPerfil>();
                    response =  ctx_siac.TblPerfils.FromSqlInterpolated($@"EXEC {SP} @PageSize = {0}, @PageNumber = {0}, @TipoConsulta = 'Perfil' ,@Id = {null}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("CatUsuarios");
                    dt.Columns.Remove("RelPerfilvista");
                    dt.Columns.Remove("Usuarios");
                }
                else if (SP == "sp_NivelModalidad_Select")
                {
                    List<CatNivelModalidad> response = new List<CatNivelModalidad>();
                    response = ctx_siac.CatNivelModalidads.FromSqlInterpolated($@"EXEC  {SP} @PageSize = {0}, @PageNumber = {0} ,@Id = {null}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("CatPonderacions");
                    dt.Columns.Remove("RelCampusnivelmodalidads");
                    dt.Columns.Remove("RelArearesponsablenivelmodalidads");
                    dt.Columns.Remove("ConfElementoEvaluacions");

                }
                else if (SP == "sp_Usuario_Select")
                {
                    List<VwUsuarioBase> response = new List<VwUsuarioBase>();
                    response = ctx_siac.VwUsuarioBases.FromSqlInterpolated($@"EXEC  {SP} @TipoConsulta = {"UsuarioLista"}, @Id = {null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("CatNivelRevisionId");
                    dt.Columns.Remove("NivelRevision");
                    dt.Columns.Remove("TblPerfilId");
                    dt.Columns.Remove("Todos");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_PeriodoEvaluacion_Select")
                {
                    List<VwCatPeriodoEvaluacion> response = new List<VwCatPeriodoEvaluacion>();
                    response = ctx_siac.VwCatPeriodoEvaluacions.FromSqlInterpolated($@"EXEC  {SP} @TipoConsulta = {"PeriodoEvaluacionEtapas"}, @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("IdPeriodoEvaluacion");
                    dt.Columns.Remove("IdInstitucion");
                    dt.Columns.Remove("IdRelEtapaPeriodoEvaluacion");
                    dt.Columns.Remove("IdEtapa");
                    dt.Columns.Remove("Activo");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Campus_Select")
                {
                    List<VwCatCampus> response = new List<VwCatCampus>();
                    response = ctx_siac.VwCatCampuses.FromSqlInterpolated($@"EXEC  {SP} @TipoConsulta = {"CampusLista"}, @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("IdRegion");
                    dt.Columns.Remove("Id");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                    dt.Columns.Remove("NivelModalidadIds");
                    
                }
                else if (SP == "sp_AreaResponsable_Select")
                {
                    List<VwCatAreaResponsable> response = new List<VwCatAreaResponsable>();
                    response = ctx_siac.VwCatAreaResponsables.FromSqlInterpolated($@"EXEC  {SP} @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("Id");
                    dt.Columns.Remove("IdAreaResponsablePadre");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                    dt.Columns.Remove("CatDependenciaAreaId");
                    dt.Columns.Remove("NivelModalidadIds");
                }
                else if (SP == "sp_DependenciaArea_Select")
                {
                    List<VwCatDependenciaArea> response = new List<VwCatDependenciaArea>();
                    response = ctx_siac.VwCatDependenciaAreas.FromSqlInterpolated($@"EXEC  {SP} @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_AreaCorporativa_Select")
                {
                    List<VwCatAreaCorporativa> response = new List<VwCatAreaCorporativa>();
                    response = ctx_siac.VwCatAreaCorporativas.FromSqlInterpolated($@"EXEC  {SP} @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    
                    
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_SubAreaCorporativa_Select")
                {
                    List<VwCatSubAreaCorporativa> response = new List<VwCatSubAreaCorporativa>();
                    response = ctx_siac.VwCatSubAreaCorporativas.FromSqlInterpolated($@"EXEC  {SP} @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);


                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Componente_Select")
                {
                    List<CatComponente> response = new List<CatComponente>();
                    response = ctx_siac.CatComponentes.FromSqlInterpolated($@"EXEC  {SP} @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("Id");
                    dt.Columns.Remove("CatPonderacions");
                    
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Ponderacion_Select")
                {
                    List<VwCatPonderacion> response = new List<VwCatPonderacion>();
                    response = ctx_siac.VwCatPonderacions.FromSqlInterpolated($@"EXEC  {SP}  @IdComponente = {null}, @IdNivelModalidad = {null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

//                    dt.Columns.Remove("Id");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_ComponenteUvm_Select")
                {
                    List<VwComponenteUvm> response = new List<VwComponenteUvm>();
                    response = ctx_siac.VwComponenteUvms.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_IndicadorUvm_Select")
                {
                    List<VwIndicadorUvm> response = new List<VwIndicadorUvm>();
                    response = ctx_siac.VwIndicadorUvms.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_SubIndicadorUvm_Select")
                {
                    List<VwSubIndicadorUvm> response = new List<VwSubIndicadorUvm>();
                    response = ctx_siac.VwSubIndicadorUvms.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Normativa_Select")
                {
                    List<CatNormativa> response = new List<CatNormativa>();
                    response = ctx_siac.CatNormativas.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                    dt.Columns.Remove("ConfIndicadorSiacs");
                    
                }
                else if (SP == "sp_ElementoEvaluacion_Select")
                {
                    List<CatElementoEvaluacion> response = new List<CatElementoEvaluacion>();
                    response = ctx_siac.CatElementoEvaluacions.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                    dt.Columns.Remove("ConfElementoEvaluacions");

                    
                }
                else if (SP == "sp_IndicadorSIAC_Select")
                {
                    List<VwCatIndicadorSiac> response = new List<VwCatIndicadorSiac>();
                    response = ctx_siac.VwCatIndicadorSiacs.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                    
                }
                else if (SP == "sp_ConfiguracionElementoEvaluacion_Select")
                {
                    List<VwConfElementoEvaluacion> response = new List<VwConfElementoEvaluacion>();
                    //response = ctx_siac.VwCatIndicadorSiacs.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    response = ctx_siac.VwConfElementoEvaluacions.FromSqlInterpolated($@"EXEC {SP} @TipoConsulta={"ConfiguracionElementoEvaluacionLista"}, @Id = {null}, @PageSize = {null}, @PageNumber = {null}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("Id");
                    dt.Columns.Remove("CatPeriodoEvaluacionId");
                    dt.Columns.Remove("IdCiclo");
                    dt.Columns.Remove("IdInstitucion");
                    dt.Columns.Remove("CatAreaResponsableId");
                    dt.Columns.Remove("CatNivelModalidadId");
                    dt.Columns.Remove("CatComponenteId");
                    dt.Columns.Remove("CatElementoEvaluacionId");
                    dt.Columns.Remove("CatAreaCorporativaId");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");

                }

                else if (SP == "sp_ConfiguracionIndicadorSIAC_Select")
                {

                    
                    List<VwConfIndicadorSiac> response = new List<VwConfIndicadorSiac>();
                    //response = ctx_siac.VwCatIndicadorSiacs.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    response = ctx_siac.VwConfIndicadorSiacs.FromSqlInterpolated($@"EXEC {SP} @TipoConsulta ={"ConfiguracionIndicadorSIACLista"}, @Id = {null}, @PageSize = {null}, @PageNumber = {null}").ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("Id");
                    dt.Columns.Remove("ConfElementoEvaluacionId");
                    dt.Columns.Remove("CatIndicadorSiacId");
                    dt.Columns.Remove("ComponenteUvmId");
                    dt.Columns.Remove("IndicadorUvmId");
                    dt.Columns.Remove("SubindicadorUvmId");
                    dt.Columns.Remove("CatPeriodoEvaluacionId");
                    dt.Columns.Remove("Anio");
                    dt.Columns.Remove("IdCiclo");
                    dt.Columns.Remove("Ciclo");
                    dt.Columns.Remove("IdInstitucion");
                    dt.Columns.Remove("Institucion");
                    dt.Columns.Remove("Proceso");
                    dt.Columns.Remove("CatAreaResponsableId");
                    dt.Columns.Remove("AreaResponsable");
                    dt.Columns.Remove("CatNivelModalidadId");
                    dt.Columns.Remove("NivelModalidad");
                    dt.Columns.Remove("CatComponenteId");
                    dt.Columns.Remove("ClaveComponente");
                    dt.Columns.Remove("Componente");
                    dt.Columns.Remove("CatElementoEvaluacionId");
                    dt.Columns.Remove("ClaveElementoEvaluacion");
                    dt.Columns.Remove("ElementoEvaluacion");
                    dt.Columns.Remove("CatAreaCorporativaId");
                    dt.Columns.Remove("SiglasAreaCorporativa");
                    dt.Columns.Remove("AreaCorporativa");
                    dt.Columns.Remove("SubareasAreaCorporativa");
                    dt.Columns.Remove("CatNormativaId");
                    dt.Columns.Remove("CatEvidenciaId");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");

                }
                else if (SP == "sp_ConfiguracionEscalaMedicion_Select")
                {

                    List<VwEscalaMedicionCondicionExcel> response = new List<VwEscalaMedicionCondicionExcel>();
                    //response = ctx_siac.VwCatIndicadorSiacs.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    response = ctx_siac.VwEscalaMedicionCondicionExcels.FromSqlInterpolated($@"EXEC {SP} @TipoConsulta ={"EscalaMedicionCondicionExcel"}, @Id = {null}, @PageSize = {null}, @PageNumber = {null}").ToList();
                    dt = ToDataTable(response);

                    

                }
                else if (SP == "sp_InstitucionesAcreditadoras_Select")
                {
                    
                    List<Datos.ModelosDBSGAPI.Entities.Acreditadora> response = new List<Datos.ModelosDBSGAPI.Entities.Acreditadora>();
                    response = ctx_fimpes.Acreditadoras.Where(x=>x.Activo == true).ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("AcreditadoraProcesos");
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Sede_Select")
                {

                    //List<CatSede> response = new List<CatSede>();
                    //response = ctx_siac.CatSedes.FromSqlInterpolated($@"EXEC  {SP}  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    //dt = ToDataTable(response);

                    //dt.Columns.Remove("FechaCreacion");
                    //dt.Columns.Remove("UsuarioCreacion");
                    //dt.Columns.Remove("FechaModificacion");
                    //dt.Columns.Remove("UsuarioModificacion");

                    var response = (from x in ctx_fimpes.Sedes
                                            select new SedeDTO
                                            {
                                                SedeId = x.SedeId,
                                                Nombre = x.Nombre,
                                                Activo = x.Activo,
                                                FechaCreacion = x.FechaCreacion,
                                                UsuarioCreacion = x.UsuarioCreacion,
                                                FechaModificacion = x.FechaModificacion,
                                                UsuarioModificacion = x.UsuarioModificacion
                                            }
                                         ).ToList();
                    dt = ToDataTable(response);

                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Evidencia_Select")
                {

                    List<VwCatEvidencium> response = new List<VwCatEvidencium>();
                    response = ctx_siac.VwCatEvidencia.FromSqlInterpolated($@"EXEC  {SP}  @TipoConsulta = {"EvidenciaLista"},  @Id={null}, @PageSize = {0}, @PageNumber = {0}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Capitulo_Select")
                {

                    List<CapituloDTO> response = new List<CapituloDTO>();
                    
                    response = (from x in ctx_fimpes.Capitulos
                                            select new CapituloDTO
                                            {
                                                AcreditadoraProcesoId = x.AcreditadoraProcesoId,
                                                CapituloId = x.CapituloId,
                                                Nombre = x.Nombre,
                                                Descripcion = x.Descripcion,
                                                FechaCreacion = x.FechaCreacion,
                                                UsuarioCreacion = x.UsuarioCreacion,
                                                FechaModificacion = x.FechaModificacion,
                                                UsuarioModificacion = x.UsuarioModificacion

                                            }).ToList();


                    dt = ToDataTable(response);
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Criterio_Select")
                {

                    List<CriterioDTO> response = new List<CriterioDTO>();

                    response = (from x in ctx_fimpes.Criterios
                    
                    select new CriterioDTO
                                            {
                                                AcreditadoraProcesoId = x.AcreditadoraProcesoId,
                                                CriterioId = x.CriterioId,
                                                CarreraId = x.CarreraId,
                                                CapituloId = x.CapituloId,
                                                TipoEvidenciaId = x.TipoEvidenciaId,
                                                Descripcion = x.Descripcion,
                                                FechaCreacion = x.FechaCreacion,
                                                UsuarioCreacion = x.UsuarioCreacion,
                                                FechaModificacion = x.FechaModificacion,
                                                UsuarioModificacion = x.UsuarioModificacion
                                            }
                                         ).ToList();


                    dt = ToDataTable(response);
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }



            }
            catch (Exception ex)
            {
                dt = new DataTable();
            }
            return dt;
        }


        public DataTable Get(String SP, int? idAcreditadoraProceso, string? idCarrera)
        {
            DataTable dt = new DataTable();
            try
            {
                Object resultados = null;
                SP = "sp_" + SP + "_Select";
                if (SP == "sp_Capitulo_Select")
                {

                    List<CapituloDTO> response = new List<CapituloDTO>();

                    response = (from x in ctx_fimpes.Capitulos
                                where x.AcreditadoraProcesoId == idAcreditadoraProceso
                                select new CapituloDTO
                                {
                                    AcreditadoraProcesoId = x.AcreditadoraProcesoId,
                                    CapituloId = x.CapituloId,
                                    Nombre = x.Nombre,
                                    Descripcion = x.Descripcion,
                                    FechaCreacion = x.FechaCreacion,
                                    UsuarioCreacion = x.UsuarioCreacion,
                                    FechaModificacion = x.FechaModificacion,
                                    UsuarioModificacion = x.UsuarioModificacion

                                }).ToList();


                    dt = ToDataTable(response);
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }
                else if (SP == "sp_Criterio_Select")
                {

                    List<CriterioDTO> response = new List<CriterioDTO>();

                    response = (from x in ctx_fimpes.Criterios
                                where
                                        x.AcreditadoraProcesoId == idAcreditadoraProceso && x.CarreraId == idCarrera
                                select new CriterioDTO

                                {
                                    AcreditadoraProcesoId = x.AcreditadoraProcesoId,
                                    CriterioId = x.CriterioId,
                                    CarreraId = x.CarreraId,
                                    CapituloId = x.CapituloId,
                                    TipoEvidenciaId = x.TipoEvidenciaId,
                                    Descripcion = x.Descripcion,
                                    FechaCreacion = x.FechaCreacion,
                                    UsuarioCreacion = x.UsuarioCreacion,
                                    FechaModificacion = x.FechaModificacion,
                                    UsuarioModificacion = x.UsuarioModificacion
                                }
                                         ).ToList();


                    dt = ToDataTable(response);
                    dt.Columns.Remove("FechaCreacion");
                    dt.Columns.Remove("UsuarioCreacion");
                    dt.Columns.Remove("FechaModificacion");
                    dt.Columns.Remove("UsuarioModificacion");
                }


            }
            catch (Exception ex)
            {
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }

}

