using Datos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio.AcreditadoraNegocio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AcreditadoraController : ControllerBase
    {
        

        private readonly ILogger<AcreditadoraController> _logger;
        public AcreditadoraNegocio negocio = new AcreditadoraNegocio();

        public AcreditadoraController(ILogger<AcreditadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int pageNumber = 0, int pageSize = 5)
        {
            return negocio.Get(null, pageSize, pageNumber);
        }

       
    }
}