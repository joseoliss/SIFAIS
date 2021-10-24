using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoResponsable
{
    public interface ITipoResponsableBLL
    {
        Respuesta ListTipoResponsable(ApplicationDbContext context);
        Respuesta AddTipoResponsable(ApplicationDbContext context, TblTipoResponsable oTipoResponsable);
        Respuesta EditTipoResponsable(ApplicationDbContext context, TblTipoResponsable oTipoResponsable);
        Respuesta DeleteTipoResponsable(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del tipoResponsable</param>
        /// <returns></returns>
        Respuesta ChangeStateTipoResponsable(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListTipoResponsable(ApplicationDbContext context);
    }
}
