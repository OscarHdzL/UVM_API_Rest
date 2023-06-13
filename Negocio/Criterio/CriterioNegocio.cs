
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Respuesta;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Datos.ModelosDBSGAPI.Entities;
using Datos.Modelos;
using Datos.ModelosDBSIAC.Entities;

namespace Negocio.Criterio
{
    public class CriterioNegocio
    {
        public AppSGAPIDbContext ctx = new AppSGAPIDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int idAcreditadoraProceso, string idCarrera)
        {
            try
            {
                var resultados2 = await (from x in ctx.Criterios
                                         where
                                         x.AcreditadoraProcesoId == idAcreditadoraProceso && x.CarreraId == idCarrera
                                         select new CriterioDTO
                                         {
                                             AcreditadoraProcesoId = x.AcreditadoraProcesoId,
                                             CriterioId = x.CriterioId,
                                             CarreraId = x.CarreraId,
                                             CapituloId = x.CapituloId,
                                             TipoEvidenciaId = x.TipoEvidenciaId,
                                             Descripcion = x.Descripcion,
                                             FechaCreacion = x.FechaCreacion,
                                             UsuarioCreacion = x.UsuarioCreacion,
                                             FechaModificacion = x.FechaModificacion,
                                             UsuarioModificacion = x.UsuarioModificacion
                                         }
                                         ).ToListAsync();
                CriterioDTO criterio_dto = new CriterioDTO();
                this.Respuesta = TipoAccion.Positiva(resultados2);
            }
            catch (Exception ex)
            {
                this.Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return this.Respuesta;
        }


        


    }
}
