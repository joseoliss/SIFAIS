using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoDonacion
{
    public class TipoDonacionBLL : ITipoDonacionBLL
    {
        public Respuesta AddTipoDonacion(ApplicationDbContext context, TblTipoDonacion oTipoDonacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblTipoDonacions.Add(oTipoDonacion);
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

        public Respuesta ChangeStateTipoDonaciones(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoDonacionDB = context.TblTipoDonacions.Find(id);
                if (tipoDonacionDB.Estado)
                {
                    tipoDonacionDB.Estado = false;
                } 
                else
                {
                    tipoDonacionDB.Estado = true;
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

        public Respuesta GetyById(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblTipoDonacions.Find(id);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta DeleteTipoDonacion(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoDonacionDB = context.TblTipoDonacions.Find(id);
                context.TblTipoDonacions.Remove(tipoDonacionDB);
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

        public Respuesta EditTipoDonacion(ApplicationDbContext context, TblTipoDonacion oTipoDonacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoDonacionDB = context.TblTipoDonacions.Find(oTipoDonacion.Id);
                tipoDonacionDB.Descripcion = oTipoDonacion.Descripcion;
                tipoDonacionDB.Detalles = oTipoDonacion.Detalles;
                tipoDonacionDB.Estado = oTipoDonacion.Estado;
                context.Update(tipoDonacionDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListTipoDonaciones(ApplicationDbContext context)
        {
            return (from s in context.TblTipoDonacions
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
                    {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });
        }

        public List<SelectListItem> GetListTipoDonacionesRep(ApplicationDbContext context)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            SelectListItem lstItem = new SelectListItem()
            {
                Text = "-Todos-",
                Value = "%%"
            };

            lst = (from s in context.TblTipoDonacions
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
                    {
                        Text = i.Descripcion,
                        Value = i.Descripcion
                    }).ToList();

            lst.Insert(0,lstItem);
            return lst;
        }

        public Respuesta ListTipoDonaciones(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblTipoDonacions.ToList();
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
