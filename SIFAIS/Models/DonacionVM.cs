using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class DonacionVM
    {
        public TblDonacione Donacion { get; set; }
        public IEnumerable<SelectListItem> lstTipoDonacion { get; set; }
        public IEnumerable<SelectListItem> lstDocumentacionSifais { get; set; }
        public IEnumerable<SelectListItem> lstMensajero { get; set; }
        public IEnumerable<SelectListItem> lstEspacio { get; set; }
        public IEnumerable<SelectListItem> lstResponsable { get; set; }
        public IEnumerable<SelectListItem> lstDonante { get; set; }
        public IEnumerable<SelectListItem> lstSede { get; set; }
    }
}
