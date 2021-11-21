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
        Respuesta ListHistorialPrestamos(ApplicationDbContext context);
        Respuesta AddActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados);
        Respuesta EditActivosPrestados(ApplicationDbContext context, TblActivosPrestado oActivosPrestados);
        Respuesta DeleteActivosPrestados(ApplicationDbContext context, int id);
        Respuesta GetyById(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para devolver los activos prestados.
        /// </summary>
        /// <param name="context">ApplicationDbContext</param>
        /// <param name="data">Id activo - Id activoPrestado</param>
        /// <returns></returns>
        Respuesta DevolverActivoPrestado(ApplicationDbContext context, string data);
    }
}
