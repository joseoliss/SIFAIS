using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using SIFAIS.Modelos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class RepPreviewListadoActivosVM
    {
        public TblActivosFisico Activos { get; set; }
        public TblTipoActivo TipoActivo { get; set; }
        public TblEstadoActivo EstadoActivo { get; set; }
        public TblResponsable ResponsablePrestamo { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public IEnumerable<SelectListItem> lstTipoActivo { get; set; }
        public IEnumerable<SelectListItem> lstEstadoActivo { get; set; }
        public IEnumerable<SelectListItem> lstResponsablePrestamo { get; set; }

        /// <summary>
        /// Retorna la lista de los activos filtrados
        /// </summary>
        public IEnumerable<ActivosFisicosView> lstActivos { get; set; }

        /// <summary>
        /// Retorna la lista de activos prestadps
        /// </summary>
        public IEnumerable<ActivosPrestadosView> lstPrestamos { get; set; }
    }
}
