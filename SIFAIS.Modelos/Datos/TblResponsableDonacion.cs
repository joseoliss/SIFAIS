using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblResponsableDonacion
    {
        public TblResponsableDonacion()
        {
            TblDonaciones = new HashSet<TblDonacione>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        public string Apellido { get; set; }

        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Display(Name = "Teléfono celular")]
        public string Celular { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de correo electrónico inválido")]
        [Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblDonacione> TblDonaciones { get; set; }
    }
}
