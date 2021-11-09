using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class DonacionesView
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha donación")]
        public DateTime FechaDonacion { get; set; }

        public string Cantidad { get; set; }

        [Display(Name = "Tipo de donación")]
        public string TipoDonacion { get; set; }

        [Display(Name = "Origen")]
        public string Donante { get; set; }

        [Display(Name = "Documentación")]
        public string DocumentacionSifais { get; set; }
        public string Mensajero { get; set; }
        public string Espacio { get; set; }

        [Display(Name = "Responsable")]
        public string ResponsableDonacion { get; set; }


    }
}
