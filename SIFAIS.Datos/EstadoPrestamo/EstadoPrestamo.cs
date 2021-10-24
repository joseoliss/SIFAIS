using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.EstadoPrestamo
{
    public class EstadoPrestamo : IEstadoPrestamo
    {
        public Respuesta AddEstadoPrestamo(ApplicationDbContext context, TblEstadoPrestamo oEstadoPrestamo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblEstadoPrestamos.Add(oEstadoPrestamo);
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

        public Respuesta ChangeStateEstadoPrestamo(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var estadoPrestamoDB = context.TblEstadoPrestamos.Find(id);
                if (estadoPrestamoDB.Estado)
                {
                    estadoPrestamoDB.Estado = false;
                }
                else
                {
                    estadoPrestamoDB.Estado = true;
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

        public Respuesta DeleteEstadoPrestamo(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var estadoPrestamoDB = context.TblEstadoPrestamos.Find(id);
                context.TblEstadoPrestamos.Remove(estadoPrestamoDB);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al eliminar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta EditEstadoPrestamo(ApplicationDbContext context, TblEstadoPrestamo oEstadoPrestamo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var estadoPrestamoDB = context.TblEstadoPrestamos.Find(oEstadoPrestamo.Id);
                estadoPrestamoDB.Descripcion = oEstadoPrestamo.Descripcion;
                estadoPrestamoDB.Detalles = oEstadoPrestamo.Detalles;
                estadoPrestamoDB.Estado = oEstadoPrestamo.Estado;
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

        public IEnumerable<SelectListItem> GetListEstadoPrestamo(ApplicationDbContext context)
        {
            return context.TblEstadoPrestamos.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListEstadoPrestamo(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblEstadoPrestamos.ToList();
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
