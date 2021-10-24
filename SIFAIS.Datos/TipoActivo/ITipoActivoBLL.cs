using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoActivo
{
    public interface ITipoActivoBLL
    {
        Respuesta ListTipoActivo(ApplicationDbContext context);
        Respuesta AddTipoActivo(ApplicationDbContext context, TblTipoActivo oTipoActivo);
        Respuesta EditTipoActivo(ApplicationDbContext context, TblTipoActivo oTipoActivo);
        Respuesta DeleteTipoActivo(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del tipoActivo</param>
        /// <returns></returns>
        Respuesta ChangeStateTipoActivo(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListTipoActivo(ApplicationDbContext context);
    }
}
