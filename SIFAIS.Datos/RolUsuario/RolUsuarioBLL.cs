using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.RolUsuario
{
    public class RolUsuarioBLL : IRolUsuarioBLL
    {
        public Respuesta GetById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from r in context.TblRolUsuarios
                                    where r.Id == id
                                    select r).FirstOrDefault();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Estado = 0;
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
            }
            return oRespuesta;
        }

        public IEnumerable<SelectListItem> GetListRolUsuario(ApplicationDbContext context)
        {
            return (from r in context.TblRolUsuarios
                    select r).Select(i => new SelectListItem 
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }
    }
}
