using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class ResponsableActivoView
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }
        public bool Estado { get; set; }

        [Display(Name = "Tipo Responsable")]
        public string Descripcion { get; set; }
    }
}
