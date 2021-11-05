using Microsoft.AspNetCore.Mvc.Rendering;
using SIFAIS.Modelos;
using SIFAIS.Modelos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.Mensajero
{
    public class MensajeroBLL : IMensajeroBLL
    {
        public Respuesta AddMensajero(ApplicationDbContext context, TblMensajero oMensajero)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                context.TblMensajeros.Add(oMensajero);
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
                oRespuesta.Datos = (from d in context.TblMensajeros
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

        public Respuesta ChangeStateMensajero(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var MensajeroDB = context.TblMensajeros.Find(id);
                if (MensajeroDB.Estado)
                {
                    MensajeroDB.Estado = false;
                }
                else
                {
                    MensajeroDB.Estado = true;
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

        public Respuesta DeleteMensajero(ApplicationDbContext context, int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var MensajeroDB = context.TblMensajeros.Find(id);
                context.TblMensajeros.Remove(MensajeroDB);
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

        public Respuesta EditMensajero(ApplicationDbContext context, TblMensajero oMensajero)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var MensajeroDB = context.TblMensajeros.Find(oMensajero.Id);
                MensajeroDB.Nombre = oMensajero.Nombre;
                MensajeroDB.Apellido = oMensajero.Apellido;
                MensajeroDB.Cedula = oMensajero.Cedula;
                MensajeroDB.Celular = oMensajero.Celular;
                MensajeroDB.CorreoElectronico = oMensajero.CorreoElectronico;
                MensajeroDB.Estado = oMensajero.Estado;
                context.Update(MensajeroDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<SelectListItem> GetListMensajero(ApplicationDbContext context)
        {
            return (from s in context.TblMensajeros
                    where s.Estado == true
                    select s).Select(i => new SelectListItem()
            {
                Text = i.Nombre + " " + i.Apellido,
                Value = i.Id.ToString()
            });
        }

        public Respuesta ListMensajero(ApplicationDbContext context)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                oRespuesta.Datos = context.TblMensajeros.ToList();
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
