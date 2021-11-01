using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.TipoDonante
{
    public class TipoDonanteBLL : ITipoDonanteBLL
    {
        public Respuesta AddTipoDonante(ApplicationDbContext context, TblTipoDonante oTipoDonante)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblTipoDonantes.Add(oTipoDonante);
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
                oRespuesta.Datos = context.TblTipoDonantes.Find(id);
                oRespuesta.Estado = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = "¡Ha ocurrido un error al filtrar!";
                oRespuesta.Estado = 0;
            }
            return oRespuesta;
        }

        public Respuesta ChangeStateTipoDonante(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoDonanteDB = context.TblTipoDonantes.Find(id);
                if (tipoDonanteDB.Estado)
                {
                    tipoDonanteDB.Estado = false;
                }
                else
                {
                    tipoDonanteDB.Estado = true;
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

        public Respuesta DeleteTipoDonante(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoDonanteDB = context.TblTipoDonantes.Find(id);
                context.TblTipoDonantes.Remove(tipoDonanteDB);
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

        public Respuesta EditTipoDonante(ApplicationDbContext context, TblTipoDonante oTipoDonante)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var tipoDonanteDB = context.TblTipoDonantes.Find(oTipoDonante.Id);
                tipoDonanteDB.Descripcion = oTipoDonante.Descripcion;
                tipoDonanteDB.Detalles = oTipoDonante.Detalles;
                tipoDonanteDB.Estado = oTipoDonante.Estado;
                context.Update(tipoDonanteDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListTipoDonante(ApplicationDbContext context)
        {
            return (from d in context.TblTipoDonantes
                    where d.Estado == true
                    select d).Select(i => new SelectListItem()
                    {
                        Text = i.Descripcion,
                        Value = i.Id.ToString()
                    });
        }

        public Respuesta ListTipoDonante(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblTipoDonantes.ToList();
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
