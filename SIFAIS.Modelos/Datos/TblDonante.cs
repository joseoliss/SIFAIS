using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblDonante
    {
        public TblDonante()
        {
            TblDonaciones = new HashSet<TblDonacione>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de donante es requerido")]
        [Display(Name = "Tipo de donante")]
        public int IdTipoDonante { get; set; }

        [Display(Name = "Código externo")]
        public string CodigoExterno { get; set; }

        [Required(ErrorMessage = "Nombre completo es requerido")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de correo electrónico inválido")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono fijo")]
        public int? Telefono { get; set; }

        [Display(Name = "Teléfono celular")]
        public int? Celular { get; set; }
        public bool Estado { get; set; }

        public virtual TblTipoDonante IdTipoDonanteNavigation { get; set; }
        public virtual ICollection<TblDonacione> TblDonaciones { get; set; }
    }
}
