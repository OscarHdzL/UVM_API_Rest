
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
using Azure;
using Negocio.Modelos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Datos.ModelosDBSIAC.DTO;
using System.Drawing.Printing;

namespace Negocio
{
    public class AzureStorageNegocio
    {


        private readonly string _storageConnectionString;
        private readonly string _storageContainerName;

        public AzureStorageNegocio()
        {

            IConfigurationRoot Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json", optional: false).Build();
            _storageConnectionString = Configuration.GetConnectionString("BlobStorage");
            _storageContainerName = Configuration.GetConnectionString("ContainerStorage");
            
        }



        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> DeleteAsync(string blobFilename)
        {
            BlobContainerClient client = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            BlobClient file = client.GetBlobClient(blobFilename);

            try
            {
                // Delete the file
                await file.DeleteAsync();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                               
                this.Respuesta = TipoAccion.Negativa($"Archivo no encontrado.");
            }


            this.Respuesta = TipoAccion.Positiva($"El archivo ha sido eliminado.");

            return Respuesta;
        }

        public async Task<BlobDto> DownloadAsync(int AzureStorageFileId)
        {
            // Get a reference to a container named in appsettings.json
            BlobContainerClient client = new BlobContainerClient(_storageConnectionString, _storageContainerName);
            

               
            try
            {


                var resultados = await ctx.VwAzureStorageFiles.FromSqlInterpolated($@"EXEC sp_AzureStorageFile_Select @TipoConsulta={"FilesLista"}, @Id = {AzureStorageFileId}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();

                if (resultados.Count == 0)
                {
                    throw new Exception("No se encontro el archivo.");
                }

                string blobFilename = resultados[0].Name;

                // Get a reference to the blob uploaded earlier from the API in the container from configuration settings
                BlobClient file = client.GetBlobClient(blobFilename);

                // Check if the file exists in the container
                if (await file.ExistsAsync())
                {
                    var data = await file.OpenReadAsync();
                    Stream blobContent = data;

                    // Download the file details async
                    var content = await file.DownloadContentAsync();

                    // Add data to variables in order to return a BlobDto
                    string name = blobFilename;
                    string contentType = content.Value.Details.ContentType;

                    // Create new BlobDto with blob data from variables
                    return new BlobDto { Content = blobContent, Name = name, ContentType = contentType };
                }
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
               
            }
            catch (Exception ex)
            {
                
            }

            // File does not exist, return null and handle that in requesting method
            return null;
        }

        public async Task<List<BlobDto>> ListAsync()
        {
            // Get a reference to a container named in appsettings.json
            BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            // Create a new list object for 
            List<BlobDto> files = new List<BlobDto>();

            await foreach (BlobItem file in container.GetBlobsAsync())
            {
                // Add each file retrieved from the storage container to the files list by creating a BlobDto object
                string uri = container.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }

            // Return all files to the requesting method
            return files;
        }

        public async Task<TipoAccion> UploadAsync(IFormFile blob, DateTime FechaCreacion, string UsuarioCreacion)
        {
            // Create new upload response object that we can return to the requesting method
            BlobResponseDto response = new();



            // Get a reference to a container named in appsettings.json and then create it
            BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            // Create the container if it does not exist
            await container.CreateIfNotExistsAsync();

            try
            {
                string NombreGenerado = GenerateFileName(blob.FileName);
                // Get a reference to the blob just uploaded from the API in a container from configuration settings
                BlobClient client = container.GetBlobClient(NombreGenerado);

                if (client != null && await client.ExistsAsync())
                {
                    await client.DeleteAsync();
                }

                client = container.GetBlobClient(NombreGenerado);


                // Open a stream for the file we want to upload
                await using (Stream? data = blob.OpenReadStream())
                {
                    // Upload the file async
                    await client.UploadAsync(data);
                }

                // Everything is OK and file got uploaded
                response.Status = $"File {blob.FileName} Uploaded Successfully";
                response.Error = false;
                response.Blob.Uri = client.Uri.AbsoluteUri;
                response.Blob.Name = client.Name;


                AzureStorageFileDTO archivo = new AzureStorageFileDTO();
                archivo.Id = 0;
                archivo.Url = client.Uri.AbsoluteUri;
                archivo.Name = NombreGenerado;
                archivo.FileName = blob.FileName;
                archivo.ContentType = blob.ContentType;
                archivo.Activo = true;
                archivo.FechaCreacion = FechaCreacion;
                archivo.UsuarioCreacion = UsuarioCreacion;
                archivo.FechaModificacion = null;
                archivo.UsuarioModificacion = null;

                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;

                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_AzureStorageFile_Actualiza
                                    @TipoActualiza = {"I"},
                                    @Entidad = {JsonSerializer.Serialize(archivo)}, 
                                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");

                Respuesta = new TipoAccion();
                Respuesta.id = (int)parametroId.Value;
                Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                Respuesta.Mensaje = (string)parametroMensaje.Value;

                                

            }
            // If the file already exists, we catch the exception and do not upload it
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
            {
               
                response.Status = $"File with name {blob.FileName} already exists. Please use another name to store your file.";
                response.Error = true;
                this.Respuesta = TipoAccion.Negativa($"El archivo ya existe");
            }
            // If we get an unexpected error, we catch it here and return the error message
            catch (RequestFailedException ex)
            {
                
                response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
                response.Error = true;
                this.Respuesta = TipoAccion.Negativa($"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.");
            }

            // Return the BlobUploadResponse object
            return Respuesta;
        }

        private string GenerateFileName(string fileName)
        {
            try
            {
                string strFileName = string.Empty;
                string[] strName = fileName.Split('.');
                //strFileName = CustomerName + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/"
                //   + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." +
                //   strName[strName.Length - 1];

                strFileName = Guid.NewGuid().ToString() + "." + strName[strName.Length - 1];
                return strFileName;
            }
            catch (Exception ex)
            {
                return fileName;
            }
        }

    }
}
