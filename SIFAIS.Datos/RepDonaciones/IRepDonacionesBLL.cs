using SIFAIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.RepDonaciones
{
    public interface IRepDonacionesBLL
    {
        Respuesta ListDonacionesXTipo(ApplicationDbContext context);
        Respuesta ListDonantesXTipo(ApplicationDbContext context);
    }
}
