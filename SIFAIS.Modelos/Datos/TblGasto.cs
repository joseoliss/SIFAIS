using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblGasto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de gasto es requerido")]
        [Display(Name = "Tipo de gasto")]
        public int IdTipoGasto { get; set; }

        [Required(ErrorMessage = "Sede es requerido")]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Detalle { get; set; }

        [Required(ErrorMessage = "Monto es requerido")]
        public double Monto { get; set; }
        public bool Estado { get; set; }

        public virtual TblSede IdSedeNavigation { get; set; }
        public virtual TblTipoGasto IdTipoGastoNavigation { get; set; }
    }
}
