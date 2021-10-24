using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblSede
    {
        public TblSede()
        {
            TblActivosFisicos = new HashSet<TblActivosFisico>();
            TblDonaciones = new HashSet<TblDonacione>();
            TblGastos = new HashSet<TblGasto>();
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        public string Detalles { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de correo electrónico inválido")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono")]
        public int? Telefono { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblActivosFisico> TblActivosFisicos { get; set; }
        public virtual ICollection<TblDonacione> TblDonaciones { get; set; }
        public virtual ICollection<TblGasto> TblGastos { get; set; }
        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
