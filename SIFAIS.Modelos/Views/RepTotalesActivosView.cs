using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Modelos.Views
{
    public class RepTotalesActivosView
    {
        public List<RepTotalActivosView> TotalActivosView { get; set; }
        public List<RepTotalActivosActivosView> TotalActivosActivosView { get; set; }
        public List<RepTotalActivosPrestadosView> TotalActivosPrestadosView { get; set; }
        public List<RepTotalActivosXestadoView> TotalActivosXEstadoView { get; set; }
        public List<RepTotalActivosInicioAñoView> TotalActivosInicioAñoView { get; set; }
        public List<RepTotalIngresosEnElAñoView> TotalIngresosEnElAñoView { get; set; }
        public List<RepTotalActivosXdescripcionView> TotalActivosXdescripcionView { get; set; }
    }
}
