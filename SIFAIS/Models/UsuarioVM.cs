using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIFAIS.Models
{
    public class UsuarioVM
    {
        public TblUsuario Usuario { get; set; }
        public IEnumerable<SelectListItem> LstRolUsuario { get; set; }
        public IEnumerable<SelectListItem> LstSede { get; set; }

        [Display(Name = "Nueva Contraserña")]
        public string NewPassword { get; set; }
    }
}
