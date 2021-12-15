using SIFAIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.RepDonaciones
{
    public class RepDonacionesBLL : IRepDonacionesBLL
    {

        public Respuesta ListDonacionesXTipo(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.DonacionesXTipoViews.ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error cargar las donaciones por tipo!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ListDonantesXTipo(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.DonantesXTipoViews.ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error cargar los donantes por tipo!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }
    }
}
