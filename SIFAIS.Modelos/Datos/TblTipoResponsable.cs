using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblTipoResponsable
    {
        public TblTipoResponsable()
        {
            TblResponsables = new HashSet<TblResponsable>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblResponsable> TblResponsables { get; set; }
    }
}
