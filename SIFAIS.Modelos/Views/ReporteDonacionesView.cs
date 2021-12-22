using System;
using System.Collections.Generic;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class ReporteDonacionesView
    {
        public DateTime FechaDonacion { get; set; }
        public string Origen { get; set; }
        public string Mensajero { get; set; }
        public string Documentacion { get; set; }
        public string TipoDonacion { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string Espacio { get; set; }
        public string Responsable { get; set; }
    }
}
