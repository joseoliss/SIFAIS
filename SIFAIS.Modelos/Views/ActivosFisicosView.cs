using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class ActivosFisicosView
    {
        public int Id { get; set; }
        public string Sede { get; set; }
        public string Nombre { get; set; }

        public bool Prestado { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public string Departamento { get; set; }

        [Display(Name = "Condición")]
        public string Condicion { get; set; }

        [Display(Name = "Código")]
        public string CodArticulo { get; set; }

    }
}
