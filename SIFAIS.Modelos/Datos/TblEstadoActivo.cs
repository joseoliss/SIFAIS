using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblEstadoActivo
    {
        public TblEstadoActivo()
        {
            TblActivosFisicos = new HashSet<TblActivosFisico>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblActivosFisico> TblActivosFisicos { get; set; }
    }
}
