using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Login
{
    public interface ILoginBLL
    {
        Respuesta Login(ApplicationDbContext context, TblUsuario oUsuario);
    }
}
