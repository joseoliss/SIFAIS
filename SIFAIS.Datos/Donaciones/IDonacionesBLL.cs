using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Donaciones
{
    public interface IDonacionesBLL
    {
        Respuesta ListDonaciones(ApplicationDbContext context);
        Respuesta AddDonacion(ApplicationDbContext context, TblDonacione oDonacion);
        Respuesta EditDonacion(ApplicationDbContext context, TblDonacione oDonacion);
        Respuesta DeleteDonacion(ApplicationDbContext context, int id);
        Respuesta GetById(ApplicationDbContext context, int id);
        Respuesta ListRepDonaciones(ApplicationDbContext context, string Origen, string Tipo, DateTime Desde, DateTime Hasta);
    }
}
