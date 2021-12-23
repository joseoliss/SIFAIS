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
        Respuesta ListActivosPrestadosRep(ApplicationDbContext context, string Tipo, string Estado, string Responsable, DateTime Desde, DateTime Hasta);
        Respuesta ListHistorialPrestamos(ApplicationDbContext context);
        Respuesta ListHistorialPrestamosRep(ApplicationDbContext context, string Tipo, string Estado, string Responsable, DateTime Desde, DateTime Hasta);
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
