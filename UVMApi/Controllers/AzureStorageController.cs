using Datos.Modelos;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Modelos;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AzureStorageController : ControllerBase
    {

        private readonly ILogger<AzureStorageController> _logger;
        public AzureStorageNegocio _storage = new AzureStorageNegocio();

        public AzureStorageController(ILogger<AzureStorageController> logger)
        {
            _logger = logger;
        }



        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> Get()
        //{
        //    // Get all files at the Azure Storage Location and return them
        //    List<BlobDto>? files = await _storage.ListAsync();

        //    // Returns an empty array if no files are present at the storage container
        //    return StatusCode(StatusCodes.Status200OK, files);
        //}

        [HttpPost]
        [Route("[action]")]
        public async Task<TipoAccion> Upload(IFormFile file, [FromForm] DateTime FechaCreacion, [FromForm] string UsuarioCreacion)
        {
           return  await _storage.UploadAsync(file, FechaCreacion, UsuarioCreacion);
        }

        
        [HttpGet]
        [Route("[action]/{AzureStorageFileId}")]
        public async Task<IActionResult> Download(int AzureStorageFileId)
        {
            BlobDto? file = await _storage.DownloadAsync(AzureStorageFileId);

            // Check if file was found
            if (file == null)
            {
                // Was not, return error message to client
                return StatusCode(StatusCodes.Status500InternalServerError, $"El archivo no pudo ser descargado.");
            }
            else
            {
                // File was found, return it to client
                return File(file.Content, file.ContentType, file.Name);
            }
        }

        //[HttpGet]
        //[Route("[action]/{filename}")]
        //public async Task<TipoAccion> Delete(string filename)
        //{
        //    return await _storage.DeleteAsync(filename);

        //}

    }
}