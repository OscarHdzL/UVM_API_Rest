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
    public class CatPeriodoEvaluacionController : ControllerBase
    {


        private readonly ILogger<CatPeriodoEvaluacionController> _logger;
        public CatPeriodoEvaluacionNegocio negocio = new CatPeriodoEvaluacionNegocio();

        public CatPeriodoEvaluacionController(ILogger<CatPeriodoEvaluacionController> logger)
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
            //PAGINA 0, NO REGISTROS 1
            return negocio.GetById(id, 5, 1);
        }


        [HttpGet]
        [Route("[action]")]
        public Task<TipoAccion> GetProcesoSiguiente(int anio, int ciclo, int institucion)
        {
            //PAGINA 0, NO REGISTROS 1
            return negocio.GetSiguienteProceso(anio, ciclo, institucion, 5, 1);
        }



        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetAnios(int pageNumber = 1, int pageSize = 5)
        //{
        //    return negocio.GetAnios(null, pageSize, pageNumber);
        //}


        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetCiclos(int anio, int pageNumber = 1, int pageSize = 5)
        //{
        //    return negocio.GetCiclos(anio, pageSize, pageNumber);
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetInstituciones(int anio, int idCiclo, int pageNumber = 1, int pageSize = 5)
        //{
        //    return negocio.GetInstituciones(anio, idCiclo, pageSize, pageNumber);
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public Task<TipoAccion> GetProceso(int anio, int idCiclo, int idInstitucion, int pageNumber = 1, int pageSize = 5)
        //{
        //    return negocio.GetProcesos(anio, idCiclo, idInstitucion, pageSize, pageNumber);
        //}

        [HttpPost]
        [Route("[action]")]
        public Task<TipoAccion> Add(PeriodoEvaluacionDTO entidad)
        {
            return negocio.Insertar(entidad);
        }
        


        [HttpPut]
        [Route("[action]")]
        public Task<TipoAccion> Update(PeriodoEvaluacionDTO entidad)
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