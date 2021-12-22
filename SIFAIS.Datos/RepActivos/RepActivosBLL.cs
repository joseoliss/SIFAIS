using SIFAIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.RepActivos
{
    public class RepActivosBLL : IRepActivosBLL
    {
        public Respuesta ListRepTotalesActivo(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            SIFAIS.Modelos.Views.RepTotalesActivosView RepTotalesActivosView = new SIFAIS.Modelos.Views.RepTotalesActivosView();
            try
            {
                RepTotalesActivosView.TotalActivosView = context.RepTotalActivosViews.ToList();
                RepTotalesActivosView.TotalActivosActivosView = context.RepTotalActivosActivosViews.ToList();
                RepTotalesActivosView.TotalActivosPrestadosView = context.RepTotalActivosPrestadosViews.ToList();
                RepTotalesActivosView.TotalActivosXEstadoView = context.RepTotalActivosXestadoViews.ToList();
                RepTotalesActivosView.TotalActivosInicioAñoView = context.RepTotalActivosInicioAñoViews.ToList();
                RepTotalesActivosView.TotalIngresosEnElAñoView = context.RepTotalIngresosEnElAñoViews.ToList();
                RepTotalesActivosView.TotalActivosXdescripcionView = context.RepTotalActivosXdescripcionViews.ToList();
                oRespuesta.Datos = RepTotalesActivosView;
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error cargar las los totales de activos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

    }
}
