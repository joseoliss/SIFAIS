using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Modelos.Views
{
    public class DonanteView
    { 
        public int Id { get; set; }
        public string TipoDonante { get; set; }
        public string CodigoExterno { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public int? Telefono { get; set; }
        public int? Celular { get; set; }
        public bool Estado { get; set; }
    }
}
