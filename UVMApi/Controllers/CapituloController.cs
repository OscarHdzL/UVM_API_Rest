using Datos.Modelos;
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
    public class CapituloController : ControllerBase
    {

        private readonly ILogger<CapituloController> _logger;
        public CapitulosNegocio negocio = new CapitulosNegocio();

        public CapituloController(ILogger<CapituloController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int idAcreditadoraProceso, int pageNumber = 1, int pageSize = 5)
        {
            return negocio.Get(idAcreditadoraProceso, pageSize, pageNumber);
        }

    }
}