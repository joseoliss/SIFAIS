using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.RolUsuario
{
    public interface IRolUsuarioBLL
    {
        Respuesta GetById(ApplicationDbContext context, int id);
        IEnumerable<SelectListItem> GetListRolUsuario(ApplicationDbContext context);
    }
}
