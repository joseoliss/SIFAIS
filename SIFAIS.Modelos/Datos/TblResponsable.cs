using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblResponsable
    {
        public TblResponsable()
        {
            TblActivosPrestados = new HashSet<TblActivosPrestado>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de responsable es requerido")]
        [Display(Name = "Tipo de responsable")]
        public int IdTipoResponsable { get; set; }

        [Display(Name = "Código externo")]
        public string CodigoExterno { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        public string Apellido { get; set; }
        public int? Edad { get; set; }

        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de correo electrónico inválido")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono fijo")]
        public string Telefono { get; set; }

        [Display(Name = "Teléfono celular")]
        public string Celular { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public virtual TblTipoResponsable IdTipoResponsableNavigation { get; set; }
        public virtual ICollection<TblActivosPrestado> TblActivosPrestados { get; set; }
    }
}
