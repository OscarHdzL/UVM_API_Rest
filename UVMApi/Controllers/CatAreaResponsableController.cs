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
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CatAreaResponsableController : ControllerBase
    {

        private readonly ILogger<CatAreaResponsableController> _logger;
        public catAreaResponsableNegocio negocio = new catAreaResponsableNegocio();

        public CatAreaResponsableController(ILogger<CatAreaResponsableController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return negocio.Get(null, pageSize, pageNumber);
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetById(int id)
        {
            return negocio.GetById(id, 5, 1);
        }

        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(AreaResponsableDTO entidad)
        {
            return negocio.Insertar(entidad);
        }

        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(AreaResponsableDTO entidad)
        {
            return negocio.Actualizar(entidad);
        }

        [HttpDelete]
        [Route("[action]")]
        public Task<TipoAccion> Disable(int id)
        {
            //PAGINA 0, NO REGISTROS 1
            return negocio.Deshabilitar(id);
        }
    }
}