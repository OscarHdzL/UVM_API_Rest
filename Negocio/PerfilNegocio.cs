
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
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Negocio
{
    public class PerfilNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                
                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var Perfiles = await ctx.TblPerfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"Perfil"}, @Id = { null }, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();


                foreach (var perfil in Perfiles)
                {

                    perfil.RelPerfilvista = await ctx.RelPerfilvista.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVista"}, @Id = {perfil.Id}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                    foreach (var vista in perfil.RelPerfilvista)
                    {
                        //vista.PerfilVistaTipoAccesos = await ctx.PerfilVistaTipoAccesos.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVistaTipoAcceso"}, @Id = {vista.Id}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                        var res = await ctx.RelPerfilvistatipoaccesos.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVistaTipoAcceso"}, @Id = {vista.Id}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                    }

                    
                }

                Respuesta = TipoAccion.Positiva(Perfiles);
            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }


        public async Task<TipoAccion> Get_2(int? id, int pageSize, int pageNumber)
        {
            try
            {

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var Perfiles = await ctx.VwPerfilBases.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"Perfil"}, @Id = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                if (Perfiles.Count == 0)
                    throw new Exception("No se encontraron resultados");


                List<PerfilPermisosDTO> ListaPerfiles = new List<PerfilPermisosDTO>();

                foreach (var per in Perfiles)
                {
                    PerfilPermisosDTO perfil = new PerfilPermisosDTO();
                    perfil.Id = per.Id;
                    perfil.Nombre= per.Nombre;
                    perfil.FechaCreacion = per.FechaCreacion;
                    perfil.UsuarioCreacion = per.UsuarioCreacion;
                    perfil.UsuarioModificacion = per.UsuarioModificacion;
                    perfil.FechaModificacion= per.FechaModificacion;
                    perfil.Activo  = per.Activo;

                    List<VwVistasPerfil> VistasPermisos = await ctx.VwVistasPerfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"VistasPerfil"}, @Id = {perfil.Id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                    //var vistas = VistasPermisos.Select(m => new VistasPerfilDTO { VistaId = (int)m.IdVista, Nombre = m.Vista, Permisos = new List<PermisoDTO>() }).Distinct();
                    var vistas = VistasPermisos.Select(m => new { m.IdVista, m.Vista }).Distinct().ToList();


                    foreach (var usu in vistas)
                    {
                        VistasPerfilDTO vista = new VistasPerfilDTO();
                        vista.VistaId = (int)usu.IdVista;
                        vista.Nombre = usu.Vista;

                        var permisos = VistasPermisos.Where(x => x.IdVista == usu.IdVista).Select(m => new { m.IdTipoAcceso, m.TipoAcceso, m.TipoAccesoDescripcion }).Distinct().ToList();

                        foreach (var perm in permisos)
                        {
                            PermisoDTO permiso = new PermisoDTO();
                            permiso.Id = (int)perm.IdTipoAcceso;
                            permiso.Nombre = perm.TipoAcceso;
                            permiso.Descripcion = perm.TipoAccesoDescripcion;

                            vista.Permisos.Add(permiso);
                        }

                        perfil.Vistas.Add(vista);
                    }
                    ListaPerfiles.Add(perfil);
                }

                Respuesta = TipoAccion.Positiva(ListaPerfiles);
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

                var Perfiles = await ctx.TblPerfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"Perfil"}, @Id = {id}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();


                foreach (var perfil in Perfiles)
                {

                    perfil.RelPerfilvista = await ctx.RelPerfilvista.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVista"}, @Id = {perfil.Id}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                    foreach (var vista in perfil.RelPerfilvista)
                    {
                        //vista.PerfilVistaTipoAccesos = await ctx.PerfilVistaTipoAccesos.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVistaTipoAcceso"}, @Id = {vista.Id}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                        var res = await ctx.RelPerfilvistatipoaccesos.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVistaTipoAcceso"}, @Id = {vista.Id}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                    }


                }

                Respuesta = TipoAccion.Positiva(Perfiles);
            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }


        public async Task<TipoAccion> Insertar(PerfilDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Perfil_Actualiza
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


        public async Task<TipoAccion> Actualizar(PerfilDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Perfil_Actualiza
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

                PerfilDTO entidad = new PerfilDTO();
                entidad.Id = id;
                entidad.Activo = false;
                entidad.FechaCreacion = DateTime.Now;
                entidad.FechaModificacion = DateTime.Now;


                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Perfil_Actualiza
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
