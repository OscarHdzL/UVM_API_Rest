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
using Datos.ModelosDBSGAPI.Entities;

namespace Negocio.AcreditadoraNegocio
{
    public class AcreditadoraNegocio
    {
        public AppSGAPIDbContext ctx = new AppSGAPIDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {

                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                //var resultados = await ctx.Acreditadoras.Where(x=>x.Activo == true).ToListAsync();
                //this.Respuesta = TipoAccion.Positiva(resultados);



                var resultados2 = await (from x in ctx.Acreditadoras
                                         where
                                         x.Activo == true
                                         select new AcreditadoraDTO
                                         {
                                             AcreditadoraId = x.AcreditadoraId,
                                             Nombre = x.Nombre,
                                             Activo = x.Activo,
                                             FechaCreacion = x.FechaCreacion,
                                             UsuarioCreacion = x.UsuarioCreacion,
                                             FechaModificacion = x.FechaModificacion,
                                             UsuarioModificacion = x.UsuarioModificacion,
                                             EsFimpes = x.EsFimpes



                                         }
                     ).ToListAsync();

                this.Respuesta = TipoAccion.Positiva(resultados2);



            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;
        }


        //public async Task<TipoAccion> Add(Acreditadora entidad)
        //{

        //    try
        //    {
        //        var parametroId = new SqlParameter("@id", SqlDbType.Int);
        //        parametroId.Direction = ParameterDirection.Output;

        //        await this.ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC SP_Add_Acreditora
        //                            @Nombre = {entidad.Nombre}, @FechaCreacion = {entidad.FechaCreacion}, @UsuarioCreacion = {entidad.UsuarioCreacion}, 
        //                            @EsFimpes = {entidad.EsFimpes}, @id = {parametroId} OUTPUT");

        //        var id = (int)parametroId.Value;

        //        this.Respuesta = TipoAccion.Positiva("Alta Exitosa", id);

               
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Respuesta = TipoAccion.Negativa(ex.Message);
        //    }
            
        //    return this.Respuesta;

        //}

        public async Task<TipoAccion> Insertar(Acreditadora entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@id", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;
                
                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar,-1);
                parametroMensaje.Direction = ParameterDirection.Output;

                await this.ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC SP_Insertar_Acreditora
                                    @Nombre = {entidad.Nombre}, @FechaCreacion = {entidad.FechaCreacion}, @UsuarioCreacion = {entidad.UsuarioCreacion}, 
                                    @EsFimpes = {entidad.EsFimpes}, @id = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT" );


                this.Respuesta = new TipoAccion();
                this.Respuesta.id = (int)parametroId.Value;
                this.Respuesta.Exito = (int)parametroExito.Value == 1 ? true: false;
                this.Respuesta.Mensaje = (string)parametroMensaje.Value;


            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;

        }


        public async Task<TipoAccion> Actualizar(Acreditadora entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@id", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;

                await this.ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC SP_Actualizar_Acreditora
                                    @AcreditadoraID = {entidad.AcreditadoraId}, @Nombre = {entidad.Nombre}, @FechaModificacion = {entidad.FechaModificacion}, @UsuarioModificacion = {entidad.UsuarioModificacion}, 
                                    @EsFimpes = {entidad.EsFimpes}, @id = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                this.Respuesta = new TipoAccion();
                this.Respuesta.id = (int)parametroId.Value;
                this.Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                this.Respuesta.Mensaje = (string)parametroMensaje.Value;

            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;

        }

        public async Task<TipoAccion> Deshabilitar(int id)
        {
            try
            {
                var parametroId = new SqlParameter("@id", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;

                await this.ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC SP_Eliminar_Acreditora
                                    @AcreditadoraID = {id}, @id = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                this.Respuesta = new TipoAccion();
                this.Respuesta.id = (int)parametroId.Value;
                this.Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                this.Respuesta.Mensaje = (string)parametroMensaje.Value;

            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;

        }


    }
}
