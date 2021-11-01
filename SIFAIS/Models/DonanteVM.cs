using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class DonanteVM
    {
        public TblDonante Donante { get; set; }
        public IEnumerable<SelectListItem> LstTipoDonante { get; set; }
    }
}
