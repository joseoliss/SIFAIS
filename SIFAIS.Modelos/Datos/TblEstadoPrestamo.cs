using System;
using System.Collections.Generic;

#nullable disable

namespace SIFAIS.Modelos.Datos
{
    public partial class TblEstadoPrestamo
    {
        public TblEstadoPrestamo()
        {
            TblActivosPrestados = new HashSet<TblActivosPrestado>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TblActivosPrestado> TblActivosPrestados { get; set; }
    }
}
