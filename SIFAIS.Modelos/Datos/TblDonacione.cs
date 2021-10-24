using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblDonacione
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo donación es requerido")]
        [Display(Name = "Tipo de donación")]
        public int IdTipoDonacion { get; set; }

        [Required(ErrorMessage = "Tipo de donante es requerido")]
        [Display(Name = "Donante")]
        public int IdDonante { get; set; }

        [Required(ErrorMessage = "Sede es requerido")]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Documentación es requerido")]
        [Display(Name = "Documentación")]
        public int IdDocSifais { get; set; }

        [Required(ErrorMessage = "Mensajero es requerido")]
        [Display(Name = "Mensajero")]
        public int IdMensajero { get; set; }

        [Required(ErrorMessage = "Espacio es requerido")]
        [Display(Name = "Espacio")]
        public int IdEspacio { get; set; }

        [Required(ErrorMessage = "Responsable es requerido")]
        [Display(Name = "Responsable")]
        public int IdResponsableDonacion { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Detalles { get; set; }

        [Required(ErrorMessage = "Fecha de donación es requerido")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha incorrecto")]
        [Display(Name = "Fecha donación")]
        public DateTime FechaDonacion { get; set; }

        [Required(ErrorMessage = "Cantidad es requerido")]
        public string Cantidad { get; set; }

        public bool Estado { get; set; }

        public virtual TblDocumentacionSifai IdDocSifaisNavigation { get; set; }
        public virtual TblDonante IdDonanteNavigation { get; set; }
        public virtual TblEspacio IdEspacioNavigation { get; set; }
        public virtual TblMensajero IdMensajeroNavigation { get; set; }
        public virtual TblResponsableDonacion IdResponsableDonacionNavigation { get; set; }
        public virtual TblSede IdSedeNavigation { get; set; }
        public virtual TblTipoDonacion IdTipoDonacionNavigation { get; set; }
    }
}
