using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class ActivosPrestadosView
    {
        [Display(Name = "Id Act")]
        public int IdArticulo { get; set; }

        [Display(Name = "Nombre")]
        public string NombreActivo { get; set; }

        [Display(Name = "Descripción")]
        public string DescripcionActivo { get; set; }

        [Display(Name = "Tipo")]
        public string TipoActivo { get; set; }
        public string Departamento { get; set; }

        [Display(Name = "Lugar")]
        public string LugarPrestamo { get; set; }

        [Display(Name = "Estado")]
        public string EstadoActivo { get; set; }
        public int Cantidad { get; set; }

        [Display(Name = "Desde")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Hasta")]
        public DateTime FechaFin { get; set; }
        public string Responsable { get; set; }
        public bool Estado { get; set; }
        public bool Prestado { get; set; }
        public int Id { get; set; }
    }
}
