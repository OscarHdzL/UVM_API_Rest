
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
using System.ComponentModel;

namespace Negocio
{
    public class UsuarioPerfilPermisosNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(string correo, int pageSize, int pageNumber)
        {
            try
            {

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var Usuario = await ctx.VwUsuarioBases.FromSqlInterpolated($@"EXEC sp_Usuario_Perfil_Permisos_Select @TipoConsulta = {"Usuario"}, @Id = {null}, @Correo = {correo}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                if (Usuario.Count == 0)
                    throw new Exception("No se encontró al usuario");

                UsuarioPerfilPermisosDTO usuarioPerfil = new UsuarioPerfilPermisosDTO();
                usuarioPerfil.IdUsuario = Usuario[0].IdUsuario;
                usuarioPerfil.Nombre = String.Concat(Usuario[0].Nombre, " ", Usuario[0].Apellidos);
                usuarioPerfil.Correo = Usuario[0].Correo;
                usuarioPerfil.Perfil = Usuario[0].Perfil;
                usuarioPerfil.Campus = Usuario[0].Campus;
                usuarioPerfil.Region = Usuario[0].Region;
                usuarioPerfil.AreaResponsable = Usuario[0].AreaResponsable;

                List<VwVistasPerfil> VistasPermisos = await ctx.VwVistasPerfils.FromSqlInterpolated($@"EXEC sp_Usuario_Perfil_Permisos_Select @TipoConsulta = {"UsuarioVistasPerfil"}, @Id = {Usuario[0].TblPerfilId}, @Correo = {null}, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();

                //var vistas = VistasPermisos.Select(m => new VistasPerfilDTO { VistaId = (int)m.IdVista, Nombre = m.Vista, Permisos = new List<PermisoDTO>() }).Distinct();
                var vistas = VistasPermisos.Select(m => new { m.IdVista, m.Vista, m.TipoVista }).Distinct().ToList();

                

                foreach (var usu in vistas)
                {
                    VistasPerfilDTO vista = new VistasPerfilDTO();
                    vista.VistaId = (int)usu.IdVista;
                    vista.Nombre = usu.Vista;
                    vista.TipoVista = usu.TipoVista;
                    
                    var permisos = VistasPermisos.Where(x=> x.IdVista == usu.IdVista).Select(m => new { m.IdTipoAcceso, m.TipoAcceso, m.TipoAccesoDescripcion }).Distinct().ToList();

                    foreach (var perm in permisos)
                    {
                        PermisoDTO permiso = new PermisoDTO();
                        permiso.Id = (int)perm.IdTipoAcceso;
                        permiso.Nombre = perm.TipoAcceso;
                        permiso.Descripcion = perm.TipoAccesoDescripcion;

                        vista.Permisos.Add(permiso);
                    }


                    usuarioPerfil.Vistas.Add(vista);
                }

                Respuesta = TipoAccion.Positiva(usuarioPerfil);
            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

       





    }
}
