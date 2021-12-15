using SIFAIS.Modelos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class RepDonantesVM
    {
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public IEnumerable<DonanteView> lstDonantes { get; set; }
    }
}
