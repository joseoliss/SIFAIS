using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.EstadoPrestamo
{
    public interface IEstadoPrestamoBLL
    {
        Respuesta ListEstadoPrestamo(ApplicationDbContext context);
        Respuesta AddEstadoPrestamo(ApplicationDbContext context, TblEstadoPrestamo oEstadoPrestamo);
        Respuesta EditEstadoPrestamo(ApplicationDbContext context, TblEstadoPrestamo oEstadoPrestamo);
        Respuesta DeleteEstadoPrestamo(ApplicationDbContext context, int id);
        Respuesta GetyById(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del EstadoPrestamo</param>
        /// <returns></returns>
        Respuesta ChangeStateEstadoPrestamo(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListEstadoPrestamo(ApplicationDbContext context);
    }
}
