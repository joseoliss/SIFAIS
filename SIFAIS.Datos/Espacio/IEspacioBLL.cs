using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Espacio
{
    public interface IEspacioBLL
    {
        Respuesta ListEspacio(ApplicationDbContext context);
        Respuesta AddEspacio(ApplicationDbContext context, TblEspacio oEspacio);
        Respuesta EditEspacio(ApplicationDbContext context, TblEspacio oEspacio);
        Respuesta DeleteEspacio(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Espacio</param>
        /// <returns></returns>
        Respuesta ChangeStateEspacio(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListEspacio(ApplicationDbContext context);
    }
}
