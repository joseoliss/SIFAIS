using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblRolUsuario
    {
        public TblRolUsuario()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string Detalles { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
