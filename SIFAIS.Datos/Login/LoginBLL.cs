using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Login
{
    public class LoginBLL : ILoginBLL
    {
        public Respuesta Login(ApplicationDbContext context, TblUsuario oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var oUsuarioDB = (from u in context.TblUsuarios
                                  where u.CorreoElectronico == oUsuario.CorreoElectronico &&
                                  u.Contraseña == oUsuario.Contraseña &&
                                  u.Estado == true
                                  select u).FirstOrDefault();
                oRespuesta.Datos = oUsuarioDB;
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Estado = 0;
                oRespuesta.Mensaje = "Ha ocurrido un error al iniciar sesión";
            }
            return oRespuesta;
        }
    }
}
