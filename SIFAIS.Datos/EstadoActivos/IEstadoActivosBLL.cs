using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.EstadoActivos
{
    public interface IEstadoActivosBLL
    {
        Respuesta ListEstadoActivo(ApplicationDbContext context);
        Respuesta AddEstadoActivo(ApplicationDbContext context, TblEstadoActivo oEstadoActivo);
        Respuesta EditEstadoActivo(ApplicationDbContext context, TblEstadoActivo oEstadoActivo);
        Respuesta DeleteEstadoActivo(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del EstadoActivos</param>
        /// <returns></returns>
        Respuesta ChangeStateEstadoActivo(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListEstadoActivo(ApplicationDbContext context);
    }
}
