using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ActivosFisicos
{
    public class ActivosFisicos : IActivosFisicos
    {
        public Respuesta AddActivosFisicos(ApplicationDbContext context, TblActivosFisico oActivosFisicos)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblActivosFisicos.Add(oActivosFisicos);
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error agregar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ChangeStateActivosFisicos(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var activosFisicosDB = context.TblActivosFisicos.Find(id);
                if (activosFisicosDB.Estado)
                {
                    activosFisicosDB.Estado = false;
                }
                else
                {
                    activosFisicosDB.Estado = true;
                }
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al actualizar el estado!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta DeleteActivosFisicos(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var activosFisicosDB = context.TblActivosFisicos.Find(id);
                context.TblActivosFisicos.Remove(activosFisicosDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditActivosFisicos(ApplicationDbContext context, TblActivosFisico oActivosFisicos)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var activosFisicosDB = context.TblActivosFisicos.Find(oActivosFisicos.Id);
                activosFisicosDB.IdSede = oActivosFisicos.IdSede;
                activosFisicosDB.IdTipoActivo = oActivosFisicos.IdTipoActivo;
                activosFisicosDB.IdEstadoActivo = oActivosFisicos.IdEstadoActivo;
                activosFisicosDB.IdDepartamento = oActivosFisicos.IdDepartamento;
                activosFisicosDB.Nombre = oActivosFisicos.Nombre;
                activosFisicosDB.Descripcion = oActivosFisicos.Descripcion;
                activosFisicosDB.FechaDeIngreso = oActivosFisicos.FechaDeIngreso;
                activosFisicosDB.Foto = oActivosFisicos.Foto;
                activosFisicosDB.CodArticulo = oActivosFisicos.CodArticulo;
                activosFisicosDB.Prestado = oActivosFisicos.Prestado;
                activosFisicosDB.Estado = oActivosFisicos.Estado;
                context.SaveChanges();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al actualizar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ListActivosFisicos(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblActivosFisicos.ToList();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al cargar los datos!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }
    }
}
