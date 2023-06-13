using Datos.Modelos;
using Datos.ModelosDBSGAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio.AcreditadoraNegocio;
using Negocio.Criterio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CriterioController : ControllerBase
    {
        

        private readonly ILogger<CriterioController> _logger;
        public CriterioNegocio negocio = new CriterioNegocio();

        public CriterioController(ILogger<CriterioController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int idAcreditadoraProceso, string idCarrera)
        {
            return negocio.Get(idAcreditadoraProceso, idCarrera);
        }

       
    }
}