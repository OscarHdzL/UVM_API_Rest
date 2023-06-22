
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
                }
                else if (SP == "sp_Usuario_Select")
                {
                    List<CatNivelModalidad> response = new List<CatNivelModalidad>();
                    response = ctx_siac.CatNivelModalidads.FromSqlInterpolated($@"EXEC  {SP} @PageSize = {0}, @PageNumber = {0}, @TipoConsulta = 'Perfil' ,@Id = {null}").ToList();
                    dt = ToDataTable(response);
                    dt.Columns.Remove("CatPonderacions");
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

