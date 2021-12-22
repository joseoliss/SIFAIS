using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoDonacion
{
    public interface ITipoDonacionBLL
    {
        Respuesta ListTipoDonaciones(ApplicationDbContext context);
        Respuesta AddTipoDonacion(ApplicationDbContext context, TblTipoDonacion oTipoDonacion);
        Respuesta EditTipoDonacion(ApplicationDbContext context, TblTipoDonacion oTipoDonacion);
        Respuesta DeleteTipoDonacion(ApplicationDbContext context, int id);

        Respuesta GetyById(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del tipodonacion</param>
        /// <returns></returns>
        Respuesta ChangeStateTipoDonaciones(ApplicationDbContext context, int id);

        /// <summary>
        /// Mestodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListTipoDonaciones(ApplicationDbContext context);
        List<SelectListItem> GetListTipoDonacionesRep(ApplicationDbContext context);
    }
}
