using Datos.Modelos;
using Datos.ModelosDBSIAC.DTO;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Respuesta;
using System.Drawing.Printing;

namespace UVMApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ConfiguracionBienvenidaController : ControllerBase
    {


        private readonly ILogger<ConfiguracionBienvenidaController> _logger;
        public ConfiguracionBienvenidaNegocio negocio = new ConfiguracionBienvenidaNegocio();

        public ConfiguracionBienvenidaController(ILogger<ConfiguracionBienvenidaController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll()
        {
            return negocio.Get(null, 1, 5);
        }


        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(ConfiguracionBienvenidum entidad)
        {
            return negocio.Actualizar(entidad);
        }

        
    }
}