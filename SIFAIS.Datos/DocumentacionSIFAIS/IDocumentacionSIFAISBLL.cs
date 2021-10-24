using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.DocumentacionSIFAIS
{
    public interface IDocumentacionSIFAISBLL
    {
        Respuesta ListDocumentacionSIFAIS(ApplicationDbContext context);
        Respuesta AddDocumentacionSIFAIS(ApplicationDbContext context, TblDocumentacionSifai oDocumentacionSIFAIS);
        Respuesta EditDocumentacionSIFAIS(ApplicationDbContext context, TblDocumentacionSifai oDocumentacionSIFAIS);
        Respuesta DeleteDocumentacionSIFAIS(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del DocumentacionSIFAIS</param>
        /// <returns></returns>
        Respuesta ChangeStateDocumentacionSIFAIS(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListDocumentacionSIFAIS(ApplicationDbContext context);
    }
}
