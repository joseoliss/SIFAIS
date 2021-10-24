using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ActivosFisicos
{
    public interface IActivosFisicos
    {
        Respuesta ListActivosFisicos(ApplicationDbContext context);
        Respuesta AddActivosFisicos(ApplicationDbContext context, TblActivosFisico oActivosFisicos);
        Respuesta EditActivosFisicos(ApplicationDbContext context, TblActivosFisico oActivosFisicos);
        Respuesta DeleteActivosFisicos(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del ActivosFisicos</param>
        /// <returns></returns>
        Respuesta ChangeStateActivosFisicos(ApplicationDbContext context, int id);
    }
}
