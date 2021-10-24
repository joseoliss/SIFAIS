using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ActivosPrestados
{
    public interface IActivosPrestadosBLL
    {
        Respuesta ListActivosPrestados(ApplicationDbContext context);
        Respuesta AddActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados);
        Respuesta EditActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados);
        Respuesta DeleteActivosPrestados(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del ActivosPrestados</param>
        /// <returns></returns>
        Respuesta ChangeStateActivosPrestados(ApplicationDbContext context, int id);
    }
}
