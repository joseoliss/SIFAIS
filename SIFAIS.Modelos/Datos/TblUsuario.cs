using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblUsuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El rol de usuario es requerido")]
        [Display(Name = "Rol de usuario")]
        public int IdRolUsuario { get; set; }

        [Required(ErrorMessage = "La sede es requerida")]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Display(Name = "Código externo")]
        public string CodigoExterno { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido de usuario es requerido")]
        public string Apellido { get; set; }

        public int? Edad { get; set; }

        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de correo electrónico inválido")]
        [Required(ErrorMessage = "Correo electrónico es requerido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        public string Contraseña { get; set; }

        [Display(Name = "Teléfono fijo")]
        public int? Telefono { get; set; }

        [Display(Name = "Teléfono celular")]
        public int? Celular { get; set; }
        public bool Estado { get; set; }

        public virtual TblRolUsuario IdRolUsuarioNavigation { get; set; }
        public virtual TblSede IdSedeNavigation { get; set; }
    }
}
