using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblDocumentacionSifai
    {
        public TblDocumentacionSifai()
        {
            TblDonaciones = new HashSet<TblDonacione>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblDonacione> TblDonaciones { get; set; }
    }
}
