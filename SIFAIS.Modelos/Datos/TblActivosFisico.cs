using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblActivosFisico
    {
        public TblActivosFisico()
        {
            TblActivosPrestados = new HashSet<TblActivosPrestado>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Sede es requerido")]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Tipo de activo es requerido")]
        [Display(Name = "Tipo de activo")]
        public int IdTipoActivo { get; set; }

        [Required(ErrorMessage = "Estado activo es requerido")]
        [Display(Name = "Estado del activo")]
        public int IdEstadoActivo { get; set; }

        [Required(ErrorMessage = "Departamento es requerido")]
        [Display(Name = "Departamento")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Fecha ingreso es requerido")]
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaDeIngreso { get; set; }
        public string Foto { get; set; }

        [Display(Name = "Código de activo")]
        public string CodArticulo { get; set; }
        public bool Prestado { get; set; }
        public bool Estado { get; set; }

        public virtual TblDepartamento IdDepartamentoNavigation { get; set; }
        public virtual TblEstadoActivo IdEstadoActivoNavigation { get; set; }
        public virtual TblSede IdSedeNavigation { get; set; }
        public virtual TblTipoActivo IdTipoActivoNavigation { get; set; }
        public virtual ICollection<TblActivosPrestado> TblActivosPrestados { get; set; }

    }
}
