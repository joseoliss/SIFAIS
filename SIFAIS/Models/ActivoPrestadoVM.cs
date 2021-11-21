using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class ActivoPrestadoVM
    {
        public int IdActivo { get; set; }
        public TblActivosPrestado ActivosPrestados { get; set; }
        public IEnumerable<SelectListItem> lstResponsable { get; set; }
        public IEnumerable<SelectListItem> lstEstadoPrestamo { get; set; }
    }
}
