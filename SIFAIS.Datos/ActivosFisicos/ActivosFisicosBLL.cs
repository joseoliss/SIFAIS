using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.ActivosFisicos
{
    public class ActivosFisicosBLL : IActivosFisicosBLL
    {
        public Respuesta AddActivosFisicos(ApplicationDbContext context, TblActivosFisico oActivosFisicos)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                if (oActivosFisicos.FechaDeIngreso.Year < 1900 || oActivosFisicos.FechaDeIngreso.Year > 9999)
                {
                    oRespuesta.Mensaje = "¡La fecha debe estar entre el año 1900 y 9999!";
                }
                else
                {
                    if (oActivosFisicos.Cantidad < 1)
                    {
                        oRespuesta.Mensaje = "¡La cantidad no puede ser menor a 1!";
                        oRespuesta.Estado = 0;

                    }
                    else
                    {
                        oActivosFisicos.Estado = true;
                        oActivosFisicos.Prestado = false;
                        context.TblActivosFisicos.Add(oActivosFisicos);
                        context.SaveChanges();
                        oRespuesta.Estado = 1;
                    }
                }
                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error agregar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta GetyById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = (from d in context.TblActivosFisicos
                                    where d.Id == id
                                    select d).FirstOrDefault();
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta PrestarDevolverActivo(ApplicationDbContext context, int id, int cantidad, string accion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var activosFisicosDB = context.TblActivosFisicos.Find(id);
                if (accion == "sumar")
                {
                    activosFisicosDB.Cantidad = activosFisicosDB.Cantidad + cantidad;
                }
                else if (accion == "restar")
                {
                    activosFisicosDB.Cantidad = activosFisicosDB.Cantidad - cantidad;
                }
                context.Update(activosFisicosDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                context.SaveChanges();
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
                activosFisicosDB.Cantidad = oActivosFisicos.Cantidad;
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
                oRespuesta.Datos = (from a in context.ActivosFisicosViews
                                    where a.Cantidad > 0
                                    select a).ToList();

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
