using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblActivosPrestado
    {
        public int Id { get; set; }
        public int IdActivo { get; set; }

        [Display(Name = "Responsable")]
        public int IdResponsable { get; set; }

        [Display(Name = "Estado del préstamo")]
        public int IdEstadoPrestamo { get; set; }
        public string Detalle { get; set; }

        [Required(ErrorMessage = "Cantidad es requerido")]
        public int Cantidad { get; set; }

        [Display(Name = "Lugar de préstamo")]
        [Required(ErrorMessage = "Lugar del préstamo es requerido")]
        public string LugarPrestamo { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Fecha de inicio es requerido")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de fin")]
        [Required(ErrorMessage = "Fecha de fin es requerido")]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Días transcurridos")]
        public int? DiasTranscurridos { get; set; }
        public bool Estado { get; set; }

        public virtual TblEstadoPrestamo IdActivo1 { get; set; }
        public virtual TblActivosFisico IdActivoNavigation { get; set; }
        public virtual TblResponsable IdResponsableNavigation { get; set; }

    }
}
