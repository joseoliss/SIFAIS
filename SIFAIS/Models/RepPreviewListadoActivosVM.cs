using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using SIFAIS.Modelos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class RepPreviewDonacionesVM
    {
        public TblDonacione Donacion { get; set; }
        public TblDonante Donante { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public IEnumerable<SelectListItem> lstTipoDonacion { get; set; }
        public IEnumerable<SelectListItem> lstDonante { get; set; }
        public IEnumerable<ReporteDonacionesView> lstDonaciones { get; set; }
    }
}
