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
    public class CatMatrizUVMController : ControllerBase
    {


        private readonly ILogger<CatMatrizUVMController> _logger;
        public CatMatrizUVMNegocio negocio = new CatMatrizUVMNegocio();

        public CatMatrizUVMController(ILogger<CatMatrizUVMController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            return negocio.Get(null, pageSize, pageNumber);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetById(int id)
        //{
        //    //PAGINA 0, NO REGISTROS 1
        //    return negocio.Get(id, 1, 0);
        //}

        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(MatrizUVMDTO entidad)
        {
            return negocio.Insertar(entidad);
        }

        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(MatrizUVMDTO entidad)
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