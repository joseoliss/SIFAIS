using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class ActivoVM
    {
        public TblActivosFisico Activos { get; set; }
        public IEnumerable<SelectListItem> lstEstadoActivo { get; set; }
        public IEnumerable<SelectListItem> lstDepartamento { get; set; }
        public IEnumerable<SelectListItem> lstSede { get; set; }
        public IEnumerable<SelectListItem> lstTipoActivo { get; set; }
    }
}
