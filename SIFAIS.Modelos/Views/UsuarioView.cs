using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class UsuarioView
    {
        public string Rol { get; set; }
        public string Sede { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono Celular")]
        public int? Celular { get; set; }
        public bool Estado { get; set; }
    }
}
