using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Usuario
{
    public interface IUsuarioBLL 
    {
        Respuesta ListUsuario(ApplicationDbContext context);
        Respuesta AddUsuario(ApplicationDbContext context, TblUsuario oUsuario);
        Respuesta EditUsuario(ApplicationDbContext context, TblUsuario oUsuario);
        Respuesta DeleteUsuario(ApplicationDbContext context, int id);

        /// <summary>
        /// Metodo para cambiar el estado
        /// </summary>
        /// <param name="context">Contexto de bd</param>
        /// <param name="id">llave primaria del Usuario</param>
        /// <returns></returns>
        Respuesta ChangeStateUsuario(ApplicationDbContext context, int id);

    }
}
