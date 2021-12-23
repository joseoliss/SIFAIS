using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Responsable
{
    public interface IResponsableBLL
    {
        Respuesta ListResponsable(ApplicationDbContext context);
        Respuesta AddResponsable(ApplicationDbContext context, TblResponsable oResponsable);
        Respuesta EditResponsable(ApplicationDbContext context, TblResponsable oResponsable);
        Respuesta DeleteResponsable(ApplicationDbContext context, int id);
        Respuesta GetyById(ApplicationDbContext context, int id);
        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Responsable</param>
        /// <returns></returns>
        Respuesta ChangeStateResponsable(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListResponsable(ApplicationDbContext context);
        List<SelectListItem> GetListResponsableRep(ApplicationDbContext context);
    }
}
