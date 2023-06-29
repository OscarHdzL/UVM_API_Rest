using Datos.Modelos;
using Datos.ModelosDBSIAC.DTO;
using Datos.ModelosDBSIAC.DTO.Configuracion;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CopiadoConfiguracionController : ControllerBase
    {


        private readonly ILogger<CopiadoConfiguracionController> _logger;
        public CopiadoConfiguracionNegocio negocio = new CopiadoConfiguracionNegocio();
        

        public CopiadoConfiguracionController(ILogger<CopiadoConfiguracionController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(CopiadoConfiguracionDTO entidad)
        {
            return negocio.Insertar(entidad);
        }

    }
}