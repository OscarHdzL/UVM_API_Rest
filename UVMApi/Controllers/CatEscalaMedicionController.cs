using Datos.Modelos;
using Datos.ModelosDBSIAC.DTO;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CatEscalaMedicionController : ControllerBase
    {


        private readonly ILogger<CatEscalaMedicionController> _logger;
        public CatEscalaMedicionNegocio negocio = new CatEscalaMedicionNegocio();

        public CatEscalaMedicionController(ILogger<CatEscalaMedicionController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return negocio.Get(null, pageSize, pageNumber);
        }

    }
}