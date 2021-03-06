using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.EstadoActivos
{
    public class EstadoActivoBLL : IEstadoActivosBLL
    {
        public Respuesta AddEstadoActivo(ApplicationDbContext context, TblEstadoActivo oEstadoActivo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblEstadoActivos.Add(oEstadoActivo);
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

        public Respuesta GetyById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblEstadoActivos.Find(id);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ChangeStateEstadoActivo(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var estadoActivoDB = context.TblEstadoActivos.Find(id);
                if (estadoActivoDB.Estado)
                {
                    estadoActivoDB.Estado = false;
                }
                else
                {
                    estadoActivoDB.Estado = true;
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

        public Respuesta DeleteEstadoActivo(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var estadoActivoDB = context.TblEstadoActivos.Find(id);
                context.TblEstadoActivos.Remove(estadoActivoDB);
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

        public Respuesta EditEstadoActivo(ApplicationDbContext context, TblEstadoActivo oEstadoActivo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var estadoActivoDB = context.TblEstadoActivos.Find(oEstadoActivo.Id);
                estadoActivoDB.Descripcion = oEstadoActivo.Descripcion;
                estadoActivoDB.Detalles = oEstadoActivo.Detalles;
                estadoActivoDB.Estado = oEstadoActivo.Estado;
                context.Update(estadoActivoDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListEstadoActivo(ApplicationDbContext context)
        {
            return (from s in context.TblEstadoActivos
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public List<SelectListItem> GetListEstadoActivoRep(ApplicationDbContext context)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            SelectListItem lstItem = new SelectListItem()
            {
                Text = "-Todos-",
                Value = "%%"
            };
            lst = (from s in context.TblEstadoActivos
                   where s.Estado == true
                   select s).Select(i => new SelectListItem()
                   {
                       Text = i.Descripcion,
                       Value = i.Descripcion
                   }).ToList();
            lst.Insert(0, lstItem);
            return lst;
        }

        public Respuesta ListEstadoActivo(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblEstadoActivos.ToList();
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
