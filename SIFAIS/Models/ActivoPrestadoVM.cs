using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class ActivoPrestadoVM
    {
        public int IdActivo { get; set; }

        [Display(Name = "Nombre de Activo")]
        public string NombreActivo { get; set; }

        [Display(Name = "Descripción de Activo")]
        public string DescripcionActivo { get; set; }

        [Display(Name = "Tipo de Activo")]
        public string TipoActivo { get; set; }

        [Display(Name = "Departamento de Activo")]
        public string DepartamentoActivo { get; set; }
        public TblActivosPrestado ActivosPrestados { get; set; }
        public IEnumerable<SelectListItem> lstResponsable { get; set; }
        public IEnumerable<SelectListItem> lstEstadoPrestamo { get; set; }
    }
}
