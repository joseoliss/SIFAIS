using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoActivo
{
    public class TipoActivoBLL : ITipoActivoBLL
    {
        public Respuesta AddTipoActivo(ApplicationDbContext context, TblTipoActivo oTipoActivo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblTipoActivos.Add(oTipoActivo);
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
                oRespuesta.Datos = (from d in context.TblTipoActivos
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

        public Respuesta ChangeStateTipoActivo(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoActivoDB = context.TblTipoActivos.Find(id);
                if (tipoActivoDB.Estado)
                {
                    tipoActivoDB.Estado = false;
                }
                else
                {
                    tipoActivoDB.Estado = true;
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

        public Respuesta DeleteTipoActivo(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoActivoDB = context.TblTipoActivos.Find(id);
                context.TblTipoActivos.Remove(tipoActivoDB);
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

        public Respuesta EditTipoActivo(ApplicationDbContext context, TblTipoActivo oTipoActivo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoActivoDB = context.TblTipoActivos.Find(oTipoActivo.Id);
                tipoActivoDB.Descripcion = oTipoActivo.Descripcion;
                tipoActivoDB.Detalles = oTipoActivo.Detalles;
                tipoActivoDB.Estado = oTipoActivo.Estado;
                context.Update(tipoActivoDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListTipoActivo(ApplicationDbContext context)
        {
            return context.TblTipoActivos.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public List<SelectListItem> GetListTipoActivoRep(ApplicationDbContext context)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            SelectListItem lstItem = new SelectListItem()
            {
                Text = "-Todos-",
                Value = "%%"
            };
            lst = (from s in context.TblTipoActivos
                   where s.Estado == true
                   select s).Select(i => new SelectListItem()
                   {
                       Text = i.Descripcion,
                       Value = i.Descripcion
                   }).ToList();
            lst.Insert(0, lstItem);
            return lst;
        }

        public Respuesta ListTipoActivo(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblTipoActivos.ToList();
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
