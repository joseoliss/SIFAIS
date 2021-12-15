using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class RepDonacionGenVM
    {
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public IEnumerable<DonacionesXTipoView> lstDonacionesXTipo { get; set; }
        public IEnumerable<DonantesXTipoView> lstDonantesXTipo { get; set; }
    }
}
