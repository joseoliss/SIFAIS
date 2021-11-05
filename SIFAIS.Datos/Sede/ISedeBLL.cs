using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Sede
{
    public interface ISedeBLL
    {
        Respuesta ListSede(ApplicationDbContext context);
        Respuesta AddSede(ApplicationDbContext context, TblSede oSede);
        Respuesta EditSede(ApplicationDbContext context, TblSede oSede);
        Respuesta DeleteSede(ApplicationDbContext context, int id);
        Respuesta GetyById(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Sede</param>
        /// <returns></returns>
        Respuesta ChangeStateSede(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListSede(ApplicationDbContext context);
    }
}
