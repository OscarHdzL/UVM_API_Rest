using Azure;
using Datos.Modelos;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Respuesta;
using System.Data;
using Spire.Xls;
using System.Threading.Tasks;
using System.Net;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ExportController : ControllerBase
    {

        private readonly ILogger<ExportController> _logger;
        public ObjectExportNegocio negocio = new ObjectExportNegocio();

        public ExportController(ILogger<ExportController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]/{SP}")]
        public  FileStreamResult  GetAll(String SP)
        {
            DataTable dt_ =  negocio.Get(SP);
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            sheet.InsertDataTable(dt_, true, 1, 1);
            FileStream fileStream = new FileStream("Data.xls", FileMode.Create);
            book.SaveToStream(fileStream, Spire.Xls.FileFormat.Version2016);
            fileStream.Position = 0; 
            var contentType = "application/vnd.ms-excel";
            return File(fileStream, contentType, "Data.xls");

        }

    }
}