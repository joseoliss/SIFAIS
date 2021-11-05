using System;
using System.Collections.Generic;

#nullable disable

namespace SIFAIS.Modelos.Views
{
    public partial class DonacionesView
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDonacion { get; set; }
        public string Cantidad { get; set; }
        public string TipoDonacion { get; set; }
        public string Donante { get; set; }
        public string DocumentacionSifais { get; set; }
        public string Mensajero { get; set; }
        public string Espacio { get; set; }
        public string ResponsableDonacion { get; set; }

    }
}
