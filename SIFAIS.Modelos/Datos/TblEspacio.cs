using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblEspacio
    {
        public TblEspacio()
        {
            TblDonaciones = new HashSet<TblDonacione>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public string Detalles { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblDonacione> TblDonaciones { get; set; }
    }
}
