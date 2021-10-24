using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Donante
{
    public interface IDonanteBLL
    {
        Respuesta ListDonante(ApplicationDbContext context);
        Respuesta AddDonante(ApplicationDbContext context, TblDonante oDonante);
        Respuesta EditDonante(ApplicationDbContext context, TblDonante oDonante);
        Respuesta DeleteDonante(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Donante</param>
        /// <returns></returns>
        Respuesta ChangeStateDonante(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListDonante(ApplicationDbContext context);
    }
}
