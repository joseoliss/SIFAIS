using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoDonante
{
    public interface ITipoDonanteBLL
    {
        Respuesta ListTipoDonante(ApplicationDbContext context);
        Respuesta AddTipoDonante(ApplicationDbContext context, TblTipoDonante oTipoDonante);
        Respuesta EditTipoDonante(ApplicationDbContext context, TblTipoDonante oTipoDonante);
        Respuesta DeleteTipoDonante(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del tipodonante</param>
        /// <returns></returns>
        Respuesta ChangeStateTipoDonante(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListTipoDonante(ApplicationDbContext context);
    }
}
