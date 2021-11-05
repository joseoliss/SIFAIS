using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ResponsableDonacion
{
    public interface IResponsableDonacionBLL
    {
        Respuesta ListResponsableDonacion(ApplicationDbContext context);
        Respuesta AddResponsableDonacion(ApplicationDbContext context, TblResponsableDonacion oResponsableDonacion);
        Respuesta EditResponsableDonacion(ApplicationDbContext context, TblResponsableDonacion oResponsableDonacion);
        Respuesta DeleteResponsableDonacion(ApplicationDbContext context, int id);
        Respuesta GetyById(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del ResponsableDonacion</param>
        /// <returns></returns>
        Respuesta ChangeStateResponsableDonacion(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListResponsableDonacion(ApplicationDbContext context);
    }
}
