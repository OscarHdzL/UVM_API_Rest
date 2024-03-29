using Datos.Modelos;
using Datos.ModelosDBSIAC.DTO;
using Datos.ModelosDBSIAC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Negocio;
using Negocio.Modelos;
using Negocio.Respuesta;

namespace UVMApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UsuarioController : ControllerBase
    {


        private readonly ILogger<UsuarioController> _logger;
        public UsuarioNegocio negocio = new UsuarioNegocio();

        public UsuarioController(ILogger<UsuarioController> logger)
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
        public Task<TipoAccion> ExisteCuenta(string correo)
        {
            return negocio.ExisteCuenta(correo);
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetById(int idUsuario, int pageNumber = 1, int pageSize = 5)
        {
            return negocio.GetById(idUsuario, pageSize, pageNumber);
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetSidebar(int idUsuario)
        {
            return negocio.GetSidebar(idUsuario);
        }


        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(UsuarioRequestDTO entidad)
        {
            return negocio.Insertar(entidad);
        }


        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(UsuarioRequestDTO entidad)
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