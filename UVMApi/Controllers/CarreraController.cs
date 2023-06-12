using Datos.Modelos;
using Datos.ModelosDBSGAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio.AcreditadoraNegocio;
using Negocio.Carrera;
using Negocio.Criterio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CarreraController : ControllerBase
    {
        

        private readonly ILogger<CarreraController> _logger;
        public CarreraNegocio negocio = new CarreraNegocio();

        public CarreraController(ILogger<CarreraController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll()
        {
            return negocio.Get();
        }

       
    }
}