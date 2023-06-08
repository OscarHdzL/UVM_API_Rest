
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
using Datos.Modelos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                
                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var Usuarios = await ctx.VwUsuarioBases.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioLista"}, @Id = { null }, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                List<UsuarioResponseDTO> list = new List<UsuarioResponseDTO>();
               
                foreach (var usu in Usuarios)
                {

                    UsuarioResponseDTO obj = new UsuarioResponseDTO
                        {
                            IdUsuario = usu.IdUsuario,
                            Nombre = usu.Nombre,
                            Apellidos = usu.Apellidos,
                            Correo = usu.Correo,
                            Activo = usu.Activo,
                            CatNivelRevisionId = usu.CatNivelRevisionId,
                            NivelRevision = usu.NivelRevision,
                            TblPerfilId = usu.TblPerfilId,
                            Perfil = usu.Perfil,
                            Todos = usu.Todos,
                            FechaCreacion = usu.FechaCreacion,
                            UsuarioCreacion = usu.UsuarioCreacion,
                            FechaModificacion = usu.FechaModificacion,
                            UsuarioModificacion = usu.UsuarioModificacion
                        };

                    obj.Regiones = await ctx.VwUsuarioRegions.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioRegion"}, @Id = {usu.IdUsuario}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                    obj.Campus = await ctx.VwUsuarioCampuses.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioCampus"}, @Id = {usu.IdUsuario}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                    obj.NivelesModalidad = await ctx.VwUsuarioNivelModalidads.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioNivelModalidad"}, @Id = {usu.IdUsuario}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                    obj.AreasResponsables = await ctx.VwUsuarioAreaResponsables.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioAreaResponsable"}, @Id = {usu.IdUsuario}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                    obj.AreasCorporativas = await ctx.VwUsuarioAreaCorporativas.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioAreaCorporativa"}, @Id = {usu.IdUsuario}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                    list.Add(obj);

                }

                Respuesta = TipoAccion.Positiva(list);
            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

        public async Task<TipoAccion> GetSidebar(int? idUsuario)
        {
            try
            {

                var Usuarios = await ctx.VwUsuarioBases.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioLista"}, @Id = {idUsuario}, @PageSize = {1}, @PageNumber = {1}").ToListAsync();

                List<UsuarioSidebarResponseDTO> list = new List<UsuarioSidebarResponseDTO>();

                foreach (var usu in Usuarios)
                {

                    UsuarioSidebarResponseDTO obj = new UsuarioSidebarResponseDTO
                    {
                        IdUsuario = usu.IdUsuario,
                        Nombre = usu.Nombre,
                        Apellidos = usu.Apellidos,
                        Correo = usu.Correo,
                        Activo = usu.Activo,
                        CatNivelRevisionId = usu.CatNivelRevisionId,
                        NivelRevision = usu.NivelRevision,
                        TblPerfilId = usu.TblPerfilId,
                        Perfil = usu.Perfil,
                        Todos = usu.Todos,
                        FechaCreacion = usu.FechaCreacion,
                        UsuarioCreacion = usu.UsuarioCreacion,
                        FechaModificacion = usu.FechaModificacion,
                        UsuarioModificacion = usu.UsuarioModificacion
                    };

                    obj.VistasPerfil = await ctx.VwVistasPerfils.FromSqlInterpolated($@"EXEC sp_Usuario_Select @TipoConsulta = {"UsuarioVistasPerfil"}, @Id = {usu.TblPerfilId}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                    list.Add(obj);

                }

                Respuesta = TipoAccion.Positiva(list);
            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }


        public async Task<TipoAccion> Insertar(UsuarioRequestDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Usuario_Actualiza
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


        public async Task<TipoAccion> Actualizar(UsuarioRequestDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Usuario_Actualiza
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


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Usuario_Actualiza
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
