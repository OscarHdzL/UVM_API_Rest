using Datos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.AcreditadoraNegocio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CatTipoAccesoController : ControllerBase
    {
        

        private readonly ILogger<CatTipoAccesoController> _logger;
        public CatTipoAccesoNegocio negocio = new CatTipoAccesoNegocio();

        public CatTipoAccesoController(ILogger<CatTipoAccesoController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll( int pageNumber = 0, int pageSize = 5)
        {
            return negocio.Get(pageSize, pageNumber);
        }

       
    }
}