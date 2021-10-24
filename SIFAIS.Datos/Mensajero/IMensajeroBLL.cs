using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Mensajero
{
    public interface IMensajeroBLL
    {
        Respuesta ListMensajero(ApplicationDbContext context);
        Respuesta AddMensajero(ApplicationDbContext context, TblMensajero oMensajero);
        Respuesta EditMensajero(ApplicationDbContext context, TblMensajero oMensajero);
        Respuesta DeleteMensajero(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Mensajero</param>
        /// <returns></returns>
        Respuesta ChangeStateMensajero(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListMensajero(ApplicationDbContext context);
    }
}
