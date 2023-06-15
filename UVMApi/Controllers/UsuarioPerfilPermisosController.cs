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
    public class UsuarioPerfilPermisosController : ControllerBase
    {


        private readonly ILogger<UsuarioPerfilPermisosController> _logger;
        public UsuarioPerfilPermisosNegocio negocio = new UsuarioPerfilPermisosNegocio();

        public UsuarioPerfilPermisosController(ILogger<UsuarioPerfilPermisosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetAll(string correo)
        {
            return negocio.Get(correo, 1, 1);
        }

        

    }
}