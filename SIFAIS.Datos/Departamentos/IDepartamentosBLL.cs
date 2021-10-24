using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Departamentos
{
    public interface IDepartamentosBLL
    {
        Respuesta ListDepartamento(ApplicationDbContext context);
        Respuesta AddDepartamento(ApplicationDbContext context, TblDepartamento oDepartamento);
        Respuesta EditDepartamento(ApplicationDbContext context, TblDepartamento oDepartamento);
        Respuesta DeleteDepartamento(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Departamentos</param>
        /// <returns></returns>
        Respuesta ChangeStateDepartamento(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cargar combobox
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListDepartamento(ApplicationDbContext context);
    }
}
