using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Modelos.Views
{
    public class DonanteView
    { 
        public int Id { get; set; }

        [Display(Name = "Tipo de donante")]
        public string TipoDonante { get; set; }

        [Display(Name = "Código externo")]
        public string CodigoExterno { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono fijo")]
        public int? Telefono { get; set; }

        [Display(Name = "Teléfono celular")]
        public int? Celular { get; set; }
        public bool Estado { get; set; }
    }
}
