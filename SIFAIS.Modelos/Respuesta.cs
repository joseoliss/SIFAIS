using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Modelos
{
    public class Respuesta
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public Object Datos { get; set; }
    }
}
